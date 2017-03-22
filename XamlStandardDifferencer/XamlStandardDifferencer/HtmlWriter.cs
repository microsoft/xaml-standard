using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlStandardDifferencer
{
    public class HtmlWriter
    {
        public static String Escape(String text)
        {
            text = text.Replace("&", "&amp;");
            text = text.Replace("<", "&lt;");
            return text;
        }

        private StreamWriter _writer;

        public HtmlWriter(String filename)
        {
            _writer = new StreamWriter(filename);
        }

        public void WriteText(String text)
        {
            _writer.WriteLine(Escape(text));
        }

        public void WriteBoldText(String text)
        {
            BeginBold();
            WriteText(text);
            EndBold();
        }

        public void BeginBold()
        {
            _writer.WriteLine("<b>");
        }

        public void EndBold()
        {
            _writer.WriteLine("</b>");
        }

        public void BeginParagraph()
        {
            _writer.WriteLine("<p>");
        }

        public void EndParagraph()
        {
            _writer.WriteLine("</p>");
        }

        public void WriteParagraph(String text)
        {
            BeginParagraph();
            WriteText(text);
            EndParagraph();
        }

        public void BeginSpan(String bgcolor = null)
        {
            if (bgcolor != null)
            {
                _writer.WriteLine("<span style=\"background-color:{0}\">", bgcolor);
            }
            else
            {
                _writer.WriteLine("<span>");
            }
        }

        public void EndSpan()
        {
            _writer.WriteLine("</span>");
        }

        public void WriteSpan(String text, String bgcolor = null)
        {
            BeginSpan(bgcolor);
            WriteText(text);
            EndSpan();
        }

        public void BeginHeader1()
        {
            _writer.WriteLine("<h1>");
        }

        public void EndHeader1()
        {
            _writer.WriteLine("</h1>");
        }

        public void BeginHeader2()
        {
            _writer.WriteLine("<h2>");
        }

        public void EndHeader2()
        {
            _writer.WriteLine("</h2>");
        }

        public void BeginHeader3()
        {
            _writer.WriteLine("<h3>");
        }

        public void EndHeader3()
        {
            _writer.WriteLine("</h3>");
        }

        public void WriteHeader1(String header)
        {
            BeginHeader1();
            WriteText(header);
            EndHeader1();
        }

        public void WriteHeader2(String header)
        {
            BeginHeader2();
            WriteText(header);
            EndHeader2();
        }

        public void WriteHeader3(String header)
        {
            BeginHeader3();
            WriteText(header);
            EndHeader3();
        }

        public void WriteLineBreak()
        {
            _writer.WriteLine("<br/>");
        }

        public void WriteHorizontalRule()
        {
            _writer.WriteLine("<hr/>");
        }

        public void WriteImage(String source)
        {
            _writer.WriteLine("<img src=\"{0}\" />", source);
        }

        public void BeginUnorderedList()
        {
            _writer.WriteLine("<ul>");
        }

        public void EndUnorderedList()
        {
            _writer.WriteLine("</ul>");
        }

        public void BeginListItem()
        {
            _writer.WriteLine("<li>");
        }

        public void EndListItem()
        {
            _writer.WriteLine("</li>");
        }

        public void WriteListItem(String value)
        {
            BeginListItem();
            WriteText(value);
            EndListItem();
        }

        public void BeginTable(bool border = false)
        {
            if (border)
            {
                _writer.WriteLine("<table border=\"1\">");
            }
            else
            {
                _writer.WriteLine("<table>");
            }
        }

        public void EndTable()
        {
            _writer.WriteLine("</table>");
        }

        public void BeginTableRow(String bgColor = null)
        {
            if (bgColor != null)
            {
                _writer.WriteLine("<tr bgcolor=\"{0}\">", bgColor);
            }
            else
            {
                _writer.WriteLine("<tr>");
            }
        }

        public void EndTableRow()
        {
            _writer.WriteLine("</tr>");
        }

        public void BeginNoWrapTableData(int colspan = 1)
        {
            if (colspan == 1)
            {
                _writer.WriteLine("<td style=\"white-space:nowrap\">");
            }
            else
            {
                _writer.WriteLine("<td style=\"white-space:nowrap\" colspan=\"{0}\">", colspan);
            }
        }

        public void BeginTableData(int colspan = 1)
        {
            if (colspan == 1)
            {
                _writer.WriteLine("<td>");
            }
            else
            {
                _writer.WriteLine("<td colspan=\"{0}\">", colspan);
            }
        }

        public void EndTableData()
        {
            _writer.WriteLine("</td>");
        }

        public void BeginTableHeader(int colspan = 1)
        {
            if (colspan == 1)
            {
                _writer.WriteLine("<th>");
            }
            else
            {
                _writer.WriteLine("<th colspan=\"{0}\">", colspan);
            }
        }

        public void EndTableHeader()
        {
            _writer.WriteLine("</th>");
        }

        public void WriteTableHeader(String text, int colspan = 1)
        {
            BeginTableHeader(colspan);
            WriteText(text);
            EndTableHeader();
        }

        public void WriteTableData(String text, int colspan = 1)
        {
            BeginTableData(colspan);
            WriteText(text);
            EndTableData();
        }

        public void WriteLink(String href, String text)
        {
            _writer.WriteLine("<a href=\"{0}\">{1}</a>", href, Escape(text));
        }

        public void WriteAnchor(String name, String text)
        {
            _writer.WriteLine("<a name=\"{0}\">{1}</a>", name, Escape(text));
        }

        public void BeginPre()
        {
            _writer.WriteLine("<pre>");
        }

        public void EndPre()
        {
            _writer.WriteLine("</pre>");
        }

        public void Close()
        {
            _writer.Close();
        }
    }
}
