using BarcodeStandard;
using SkiaSharp;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Type = BarcodeStandard.Type;

namespace BarcodeMaker;

public static class BarCodeGen
{
    public static byte[] GenBarCodePNG(string codeBar, string? barType)
    {
        var b = new Barcode();
        b.IncludeLabel = true;
        
        string brType = barType ?? "";
        string codeBartext = codeBar.Trim().Length < 12 ? "123456789000" : codeBar.Trim();

        try
        {
            SKImage skImage = b.Encode(GetTypeSelected(brType), stringToEncode: codeBartext, 
                foreColor: SKColors.Black, backColor: SKColors.White, width: 290, height: 120);
            // Convert to Bitmap
            SKData pngData = skImage.Encode();
            return pngData.ToArray();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }

    }

    private static Type GetTypeSelected(string typeText)
    {
        Type type = Type.Unspecified;
        switch (typeText.Trim('"').Trim())
        {
            case "UPC-A": type = Type.UpcA; break;
            case "UPC-E": type = Type.UpcE; break;
            case "UPC 2 Digit Ext.": type = Type.UpcSupplemental2Digit; break;
            case "UPC 5 Digit Ext.": type = Type.UpcSupplemental5Digit; break;
            case "EAN-13": type = Type.Ean13; break;
            case "JAN-13": type = Type.Jan13; break;
            case "EAN-8": type = Type.Ean8; break;
            case "ITF-14": type = Type.Itf14; break;
            case "Codabar": type = Type.Codabar; break;
            case "PostNet": type = Type.PostNet; break;
            case "Bookland/ISBN": type = Type.Bookland; break;
            case "Code 11": type = Type.Code11; break;
            case "Code 39": type = Type.Code39; break;
            case "Code 39 Extended": type = Type.Code39Extended; break;
            case "Code 39 Mod 43": type = Type.Code39Mod43; break;
            case "Code 93": type = Type.Code93; break;
            case "LOGMARS": type = Type.Logmars; break;
            case "MSI Mod 10": type = Type.MsiMod10; break;
            case "MSI Mod 11": type = Type.MsiMod11; break;
            case "MSI 2 Mod 10": type = Type.Msi2Mod10; break;
            case "MSI Mod 11 Mod 10": type = Type.MsiMod11Mod10; break;
            case "Interleaved 2 of 5": type = Type.Interleaved2Of5; break;
            case "Interleaved 2 of 5 Mod 10": type = Type.Interleaved2Of5Mod10; break;
            case "Standard 2 of 5": type = Type.Standard2Of5; break;
            case "Standard 2 of 5 Mod 10": type = Type.Standard2Of5Mod10; break;
            case "Code 128": type = Type.Code128; break;
            case "Code 128-A": type = Type.Code128A; break;
            case "Code 128-B": type = Type.Code128B; break;
            case "Code 128-C": type = Type.Code128C; break;
            case "Telepen": type = Type.Telepen; break;
            case "FIM": type = Type.Fim; break;
            case "Pharmacode": type = Type.Pharmacode; break;
            default: type = Type.Ean13; break;
        }//switch

        return type;
    }

}