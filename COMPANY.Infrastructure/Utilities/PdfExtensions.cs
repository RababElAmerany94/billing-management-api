namespace COMPANY.Infrastructure.Utilities
{
    using COMPANY.Domain.Enums;
    using iTextSharp.text;
    using iTextSharp.text.html.simpleparser;
    using iTextSharp.text.pdf;
    using System.Collections;
    using System.IO;

    public static class PdfExtensions
    {
        private static readonly string _fontName = "Lato";
        private static readonly string _fontColor = "#231F20";

        public static Font GetFont(float size, int style, BaseColor color) {
            var fontFilePath = $@"{Directory.GetCurrentDirectory()}/Resources/Fonts/Lato-Regular.ttf";
            var fontBoldFilePath = $@"{Directory.GetCurrentDirectory()}/Resources/Fonts/Lato-Bold.ttf";

            if (!FontFactory.IsRegistered(_fontName))
            {
                FontFactory.Register(fontFilePath);
                FontFactory.Register(fontBoldFilePath);
            }

            return FontFactory.GetFont(_fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, size, style, color);
        }


        /// <summary>
        /// build discount phrase by concatenation between discount and discount type
        /// </summary>
        /// <param name="discount">the amount of discount</param>
        /// <param name="discountType">the type of discount</param>
        /// <returns>a phrase</returns>
        public static string BuildDiscountPhrase(this decimal discount, RemiseType? discountType)
        {
            var discountFormated = string.Format("{0:0.00}", discount);
            switch (discountType)
            {
                case RemiseType.Percent:
                    return $"{discountFormated} %";
                case RemiseType.Currency:
                    return $"{discountFormated} €";

                default:
                    return discountFormated;
            }
        }

        /// <summary>
        /// transfer HTML to paragraph
        /// </summary>
        /// <param name="html">the HTML that we want to parse</param>
        /// <returns>a paragraph instance</returns>
        public static Paragraph TransferHtmlToParagraph(this string html, Font font = null)
        {
            var p = new Paragraph("", font);

            if (string.IsNullOrEmpty(html))
                return p;

            html = $"<div style='font-family:{_fontName};color:{_fontColor};font-size:7.5px;line-height: normal;padding:0px;margin:0px;'>{html}</div>";

            // parse and get a collection of elements
            ArrayList elements = HtmlWorker.ParseToList(new StringReader(html), null);
            foreach (IElement e in elements)
            {
                // add those elements to the paragraph
                p.Add(e);
            }

            return p;
        }

    }
}
