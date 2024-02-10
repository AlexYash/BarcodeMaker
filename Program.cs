using BarcodeMaker;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "Usage:\n codeBar - numeral string to encode; \n barType - barcode type \n example: https://localhost/978020137962?barType=\"Code 128\"");

app.MapGet("/{codeBar}", (string codeBar, string? barType) => 
    Results.Bytes(BarCodeGen.GenBarCodePNG(codeBar, barType), "image/png"));

app.Run();

