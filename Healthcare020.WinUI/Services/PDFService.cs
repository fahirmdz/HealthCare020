using Healthcare020.WinUI.Properties;
using HealthCare020.Core.Extensions;
using HealthCare020.Core.Models;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;

namespace Healthcare020.WinUI.Services
{
    public class PDFService
    {
        public static void GeneratePDFDocument(PregledDtoEL pregled, string zdravstvenoStanje, string opisStanja)
        {
            if (pregled == null || string.IsNullOrWhiteSpace(opisStanja) || string.IsNullOrWhiteSpace(zdravstvenoStanje))
                return;

            var pacijent = pregled.Pacijent.ZdravstvenaKnjizica.LicniPodaci.ImePrezime();

            var document = new PdfDocument();
            var fileName = $"LekarskoUverenje_{pacijent ?? string.Empty}_{DateTime.Now.Date:d}.pdf".RemoveWhitespaces();
            document.Info.Title = fileName;
            document.Info.Author = Resources.InstitutionName;
            var page = document.AddPage();

            XImage logo;
            using (var ms = new MemoryStream())
            {
                var image = Resources.Healthcare020_Logo_250x250;
                image.Save(ms, ImageFormat.Png);
                logo = XImage.FromStream(ms);
            }

            var sideStartX = logo.PointWidth;
            var gfx = XGraphics.FromPdfPage(page);
            gfx.DrawImage(logo, page.Width - sideStartX - 10, 10);

            var options = new XPdfFontOptions(PdfFontEncoding.Unicode);
            var titleFont = new XFont("Segoe UI", 28, XFontStyle.Regular, options);
            gfx.DrawString("Lekarsko uverenje", titleFont, XBrushes.Black, new XRect(page.Width / 2 - 100, 75, page.Width, 0));
            gfx.DrawLine(XPens.LightGray, new XPoint(sideStartX + 10, 110), new XPoint(page.Width - sideStartX - 10, 110));

            var basicFontBolded = new XFont("Segoe UI", 16, XFontStyle.Bold, options);
            var basicFontRegular = new XFont("Segoe UI", 16, XFontStyle.Regular, options);

            //Pacijent
            gfx.DrawString("Pacijent:", basicFontBolded, XBrushes.Black, new XRect(sideStartX + 60, 180, page.Width, 0));
            gfx.DrawString(pacijent,
                basicFontRegular,
                XBrushes.Black,
                new XRect(sideStartX + 140, 180, page.Width, 0));

            //Doktor
            gfx.DrawString("Doktor:", basicFontBolded, XBrushes.Black, new XRect(sideStartX + 65, 230, page.Width, 0));
            gfx.DrawString(pregled.Doktor,
                basicFontRegular,
                XBrushes.Black,
                new XRect(sideStartX + 140, 230, page.Width, 0));

            //Zdravstveno stanje
            gfx.DrawString("Zdravstveno stanje:", basicFontBolded, XBrushes.Black, new XRect(sideStartX - 30, 280, page.Width, 0));
            gfx.DrawString(zdravstvenoStanje,
                basicFontRegular,
                XBrushes.Black,
                new XRect(sideStartX + 140, 280, page.Width, 0));

            //Datum
            gfx.DrawString("Datum:", basicFontBolded, XBrushes.Black, new XRect(sideStartX + 60, 330, page.Width, 0));
            gfx.DrawString(DateTime.Now.Date.ToString("d"),
                basicFontRegular,
                XBrushes.Black,
                new XRect(sideStartX + 140, 330, page.Width, 0));

            var textFormatter = new XTextFormatter(gfx);
            var format = new XStringFormat
            {
                LineAlignment = XLineAlignment.Near,
                Alignment = XStringAlignment.Near
            };

            //Opis stanja
            gfx.DrawString("Opis stanja:", basicFontBolded, XBrushes.Black, new XRect(sideStartX + 45, 380, page.Width, 0));
            textFormatter.DrawString(opisStanja,
                basicFontRegular,
                XBrushes.Black,
                new XRect(sideStartX + 80, 400, 350, 400), format);

            //Potpis
            gfx.DrawLine(XPens.Black, new XPoint(page.Width - sideStartX - 70, page.Height - 70), new XPoint(page.Width - 20, page.Height - 70));
            gfx.DrawString("Potpis doktora", basicFontBolded, XBrushes.Black, new XRect(page.Width - sideStartX - 60, page.Height - 50, page.Width, 0));

            document.Save(fileName);
            Process.Start(fileName);
        }
    }
}