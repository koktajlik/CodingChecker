using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CodingChecker
{
    public class EncodingChecker
    {
        public EncodingChecker()
        {
            
        }

        public string GetFileEncoding(string path)
        {
            if (File.Exists(path))
            {
                var extValue = GetExtension(path);
                if (extValue != null)
                {
                    switch (extValue)
                    {
                        case "xml":
                            var xmlEncoding = GetXMLEncoding(path);
                            if (xmlEncoding == null)
                            {
                                break;
                            }
                            return xmlEncoding;
                        case "json":
                            return "UTF-8";
                        case "html":
                            return GetHTMLEncoding(path);
                        default:
                            break;
                    }
                }
                
                // Checks for every encoding starting with bom
                var bomValue = CheckBom(path);
                if (bomValue != null)
                {
                    return bomValue;
                }
                
                // Checks for binary file
                var binaryValue = CheckBinary(path);
                if (binaryValue != null)
                {
                    return binaryValue;
                }
                
                //Check for ascii/utf-8 encoding
                return CheckAscii(path);
                // return "xd";

            }
            else return @"Błędna ścieżka pliku";
        }

        private string? CheckBom(string path)
        {
            byte[] bom = new byte[4];
            using (var reader = new BinaryReader(new FileStream(path, FileMode.Open)))
            {
                reader.Read(bom, 0, 4);
            }
            
            if (bom[0] == 0xEF && bom[1] == 0xBB && bom[2] == 0xBF)
            {
                return "UTF-8 with BOM";
            }
            if (bom[0] == 0xFF && bom[1] == 0xFE && bom[2] == 0x00 & bom[3] == 0x00)
            {
                return "UTF-32 LE";
            }
            if (bom[0] == 0x00 & bom[1] == 0x00 && bom[2] == 0xFE && bom[3] == 0xFF)
            {
                return "UTF-32 BE";
            }
            if (bom[0] == 0xFE && bom[1] == 0xFF)
            {
                return "UTF-16 BE";
            }
            if (bom[0] == 0xFF && bom[1] == 0xFE)
            {
                return "UTF-16 LE";
            }
            if (bom[0] == 0x2B & bom[1] == 0x2F && bom[2] == 0x76)
            {
                return "UTF-7";
            }
            if (bom[0] == 0xF7 & bom[1] == 0x64 && bom[2] == 0x4C)
            {
                return "UTF-1";
            }
            if (bom[0] == 0xDD & bom[1] == 0x73 && bom[2] == 0x66 && bom[3] == 0x73)
            {
                return "UTF-EBCDIC";
            }
            if (bom[0] == 0x0E & bom[1] == 0xFE && bom[2] == 0xFF)
            {
                return "SCSU";
            }
            if (bom[0] == 0xFB & bom[1] == 0xEE && bom[2] == 0x28)
            {
                return "BOCU-1";
            }
            if (bom[0] == 0x84 & bom[1] == 0x31 && bom[2] == 0x95 && bom[3] == 0x33)
            {
                return "GB18030";
            }

            return null;
        }

        private string? CheckBinary(string path)
        {
            var requiredNull = 4;
            var nullCounter = 0;

            var streamReader = new StreamReader(path);
            {
                while(!streamReader.EndOfStream)
                {
                    if (Convert.ToChar(streamReader.Read()) == '\0')
                    {
                        nullCounter++;
                        if (nullCounter >= requiredNull)
                            return "Binary file";
                    }
                    else
                    {
                        nullCounter = 0;
                    }
                }
            }
            streamReader.Close();
            return null;
        }

        private string CheckAscii(string path)
        {
            var binaryReader = new BinaryReader(new FileStream(path, FileMode.Open));
            {
                while(binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                {
                    if (binaryReader.Read() > 127)
                    {
                        binaryReader.Close();
                        return "UTF-8";
                    }
                }
                binaryReader.Close();
                return "ASCII";
            }
            
        }

        private string? GetExtension(string path)
        {
            var splittedPathString = path.Split('.');
            if (splittedPathString.Length == 1)
            {
                return null;
            }
            var extension = splittedPathString[splittedPathString.Length - 1];
            return extension;
        }

        private string? GetXMLEncoding(string path)
        {
            string firstLine = File.ReadLines(path).First();
            if (firstLine.Contains("encoding"))
            {
                string[] stringSeparator = new string[] { "encoding=" };
                string firstLineWithEncoding = firstLine.Replace(" ", "").Split(stringSeparator, StringSplitOptions.None)[1];
                string encodingValue = firstLineWithEncoding.Split('"')[1];
                return encodingValue;
            }
            return null;
        }

        private string GetHTMLEncoding(string path)
        {
            using(var streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    var readLine = streamReader.ReadLine();
                    if (readLine == "</head>")
                    {
                        return "UTF-8";
                    }

                    if (readLine != null && readLine.Contains("<meta charset="))
                    {
                        var encoding = readLine.Split('=')[1].Replace(">", "").Remove(0,1);
                        return encoding.Remove(encoding.Length - 1, 1);
                    }
                }

            }
            return "UTF-8";
        }
    }

}