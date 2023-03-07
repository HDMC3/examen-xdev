using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using ProductsApp.Data;

namespace ProductsApp.Services.Files;

public class GenerateProductsSpreadsheet { 
    private readonly ProductsAppDbContext _context;
    public GenerateProductsSpreadsheet(ProductsAppDbContext context) {
        _context = context;
    }

    public async Task<XLWorkbook> Generate() {
        var products = await _context.Products
            .OrderByDescending(product => product.Created)
            .ToListAsync();

        var wb = new XLWorkbook();

        var ws = wb.Worksheets.Add("Productos");

        ws.Cell("A1").SetValue("Nombre");
        ws.Cell("B1").SetValue("Descripcion");
        ws.Cell("C1").SetValue("Precio");
        ws.Cell("D1").SetValue("Fecha de creacion");
        ws.Cell("E1").SetValue("Ultima modificacion");

        var headersRange = ws.Range("A1:E1");
        headersRange.Style
            .Font.SetBold(true)
            .Font.SetFontSize(11)
            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        int rowCounter = 2;

        foreach (var product in products)
        {
            ws.Cell(rowCounter, "A").SetValue(product.Name);
            ws.Cell(rowCounter, "B").SetValue(product.Description);
            ws.Cell(rowCounter, "C").SetValue(Math.Round(product.Price, 2));
            ws.Cell(rowCounter, "D").SetValue(product.Created);
            ws.Cell(rowCounter, "E").SetValue(product.LastModified);
            rowCounter++;
        }
        ws.Columns().AdjustToContents();
        ws.RangeUsed().SetAutoFilter().Column(1);

        return wb;
    }
}