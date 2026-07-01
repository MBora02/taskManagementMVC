using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using taskManagementCrud.Models;
using Microsoft.AspNetCore.Authorization;

namespace taskManagementCrud.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        public IActionResult Delete(Department department)
        {
            department = _context.Departments.Find(department.DepartmentId);
            if (department == null)
            {
                return NotFound();
            }
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Search(string search)
        {
            var departments = _context.Departments.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                departments = departments.Where(x =>
                    x.DepartmentName.Contains(search));
            }

            return View("Index", departments.ToList());
        }

        public IActionResult ExportToPdf()
        {
            // 1. Veri tabanından güncel listeyi çekin
            var products = _context.Departments.ToList();

            // 2. QuestPDF ile PDF dökümanını tasarlayın
            var pdfDocument = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11).FontFamily("Arial"));

                    // Üst Bilgi (Header)
                    page.Header()
                        .Text("Departman Listesi Raporu")
                        .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                    // İçerik (Tablo Oluşturma)
                    page.Content()
                        .PaddingTop(1, Unit.Centimetre)
                        .Table(table =>
                        {
                            // Sütun genişliklerini tanımlayın
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(50);  // ID sütunu genişliği
                                columns.RelativeColumn();    // Pet adı sütunu (esnek)
                                columns.ConstantColumn(100); // durum sütunu genişliği
                            });

                            // Tablo Başlıkları (Header Row)
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("DepartmentId").Bold();
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Department Name").Bold();
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("DepartmentpersonelCount").Bold();
                            });

                            // Veri Satırları (Döngü ile verileri basıyoruz)
                            foreach (var item in products)
                            {
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.DepartmentId.ToString());
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.DepartmentName);
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.DepartmentpersonelCount);
                            }
                        });

                    // Alt Bilgi (Footer)
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Sayfa ");
                            x.CurrentPageNumber();
                        });
                });
            });

            // 3. PDF'i byte dizisine çevirip tarayıcıya indirtme
            var pdfBytes = pdfDocument.GeneratePdf();
            return File(pdfBytes, "application/pdf", $"Department_List_{DateTime.Now:yyyyMMdd}.pdf");
        }

        public IActionResult ExportToExcel()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Backend softito");

            // 2. Veri tabanından güncel listenizi çekin
            var products = _context.Departments.ToList();

            // 3. Bellekte (Memory) boş bir Excel dosyası oluşturun
            using (var package = new ExcelPackage())
            {
                // Excel içinde "Department Listesi" adında bir sayfa aç
                var worksheet = package.Workbook.Worksheets.Add("Department Listesi");

                // 4. Tablo Başlıklarını Yazın (1. Satır)
                worksheet.Cells[1, 1].Value = "Department ID";
                worksheet.Cells[1, 2].Value = "Department Name";
                worksheet.Cells[1, 3].Value = "DepartmentpersonelCount";

                // 5. Başlık Satırını Şıklaştırın (Arka plan rengi, kalın yazı vb.)
                using (var range = worksheet.Cells[1, 1, 1, 3]) // 1. satır, 1'den 3. sütuna kadar seç
                {
                    range.Style.Font.Bold = true; // Yazıyı kalın yap
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(41, 128, 185)); // Mavi arka plan
                    range.Style.Font.Color.SetColor(System.Drawing.Color.White); // Beyaz yazı rengi
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Ortala
                }

                // 6. Verileri Döngü ile Excel Satırlarına Basın
                int rowNumber = 2; // Veriler 2. satırdan başlayacak
                foreach (var item in products)
                {
                    worksheet.Cells[rowNumber, 1].Value = item.DepartmentId;
                    worksheet.Cells[rowNumber, 2].Value = item.DepartmentName;
                    worksheet.Cells[rowNumber, 3].Value = item.DepartmentpersonelCount;



                    rowNumber++;
                }



                //7.Sütun genişliklerini içeriğe göre otomatik ayarla

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // 8. Excel dosyasını byte dizisine çevirip tarayıcıya fırlat
                var fileBytes = package.GetAsByteArray();
                string fileName = $"Pet_Listesi_{DateTime.Now:yyyyMMdd}.xlsx";

                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);







            }
        }
    }
}
