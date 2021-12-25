using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Common.Helper
{
   public static  class MimeHelper
    {
        // 通过自己定义一个静态类
        // 将所有的Content Type都扔进去吧
        // 调用的时候直接调用静态方法即可。
        
            private static Hashtable _mimeMappingTable;

            private static void AddMimeMapping(string extension, string MimeType)
            {
                MimeHelper._mimeMappingTable.Add(extension, MimeType);
            }

            public static string GetMimeMapping(string FileName)
            {
                string text = null;
                int num = FileName.LastIndexOf('.');
                if (0 < num && num > FileName.LastIndexOf('\\'))
                {
                    text = (string)MimeHelper._mimeMappingTable[FileName.Substring(num)];
                }
                if (text == null)
                {
                    text = (string)MimeHelper._mimeMappingTable[".*"];
                }
                return text;
            }

            static MimeHelper()
            {
                MimeHelper._mimeMappingTable = new Hashtable(190, StringComparer.CurrentCultureIgnoreCase);
                MimeHelper.AddMimeMapping(".323", "text/h323");
                MimeHelper.AddMimeMapping(".asx", "video/x-ms-asf");
                MimeHelper.AddMimeMapping(".acx", "application/internet-property-stream");
                MimeHelper.AddMimeMapping(".ai", "application/postscript");
                MimeHelper.AddMimeMapping(".aif", "audio/x-aiff");
                MimeHelper.AddMimeMapping(".aiff", "audio/aiff");
                MimeHelper.AddMimeMapping(".axs", "application/olescript");
                MimeHelper.AddMimeMapping(".aifc", "audio/aiff");
                MimeHelper.AddMimeMapping(".asr", "video/x-ms-asf");
                MimeHelper.AddMimeMapping(".avi", "video/x-msvideo");
                MimeHelper.AddMimeMapping(".asf", "video/x-ms-asf");
                MimeHelper.AddMimeMapping(".au", "audio/basic");
                MimeHelper.AddMimeMapping(".application", "application/x-ms-application");
                MimeHelper.AddMimeMapping(".bin", "application/octet-stream");
                MimeHelper.AddMimeMapping(".bas", "text/plain");
                MimeHelper.AddMimeMapping(".bcpio", "application/x-bcpio");
                MimeHelper.AddMimeMapping(".bmp", "image/bmp");
                MimeHelper.AddMimeMapping(".cdf", "application/x-cdf");
                MimeHelper.AddMimeMapping(".cat", "application/vndms-pkiseccat");
                MimeHelper.AddMimeMapping(".crt", "application/x-x509-ca-cert");
                MimeHelper.AddMimeMapping(".c", "text/plain");
                MimeHelper.AddMimeMapping(".css", "text/css");
                MimeHelper.AddMimeMapping(".cer", "application/x-x509-ca-cert");
                MimeHelper.AddMimeMapping(".crl", "application/pkix-crl");
                MimeHelper.AddMimeMapping(".cmx", "image/x-cmx");
                MimeHelper.AddMimeMapping(".csh", "application/x-csh");
                MimeHelper.AddMimeMapping(".cod", "image/cis-cod");
                MimeHelper.AddMimeMapping(".cpio", "application/x-cpio");
                MimeHelper.AddMimeMapping(".clp", "application/x-msclip");
                MimeHelper.AddMimeMapping(".crd", "application/x-mscardfile");
                MimeHelper.AddMimeMapping(".deploy", "application/octet-stream");
                MimeHelper.AddMimeMapping(".dll", "application/x-msdownload");
                MimeHelper.AddMimeMapping(".dot", "application/msword");
                MimeHelper.AddMimeMapping(".doc", "application/msword");
                MimeHelper.AddMimeMapping(".dvi", "application/x-dvi");
                MimeHelper.AddMimeMapping(".dir", "application/x-director");
                MimeHelper.AddMimeMapping(".dxr", "application/x-director");
                MimeHelper.AddMimeMapping(".der", "application/x-x509-ca-cert");
                MimeHelper.AddMimeMapping(".dib", "image/bmp");
                MimeHelper.AddMimeMapping(".dcr", "application/x-director");
                MimeHelper.AddMimeMapping(".disco", "text/xml");
                MimeHelper.AddMimeMapping(".exe", "application/octet-stream");
                MimeHelper.AddMimeMapping(".etx", "text/x-setext");
                MimeHelper.AddMimeMapping(".evy", "application/envoy");
                MimeHelper.AddMimeMapping(".eml", "message/rfc822");
                MimeHelper.AddMimeMapping(".eps", "application/postscript");
                MimeHelper.AddMimeMapping(".flr", "x-world/x-vrml");
                MimeHelper.AddMimeMapping(".fif", "application/fractals");
                MimeHelper.AddMimeMapping(".gtar", "application/x-gtar");
                MimeHelper.AddMimeMapping(".gif", "image/gif");
                MimeHelper.AddMimeMapping(".gz", "application/x-gzip");
                MimeHelper.AddMimeMapping(".hta", "application/hta");
                MimeHelper.AddMimeMapping(".htc", "text/x-component");
                MimeHelper.AddMimeMapping(".htt", "text/webviewhtml");
                MimeHelper.AddMimeMapping(".h", "text/plain");
                MimeHelper.AddMimeMapping(".hdf", "application/x-hdf");
                MimeHelper.AddMimeMapping(".hlp", "application/winhlp");
                MimeHelper.AddMimeMapping(".html", "text/html");
                MimeHelper.AddMimeMapping(".htm", "text/html");
                MimeHelper.AddMimeMapping(".hqx", "application/mac-binhex40");
                MimeHelper.AddMimeMapping(".isp", "application/x-internet-signup");
                MimeHelper.AddMimeMapping(".iii", "application/x-iphone");
                MimeHelper.AddMimeMapping(".ief", "image/ief");
                MimeHelper.AddMimeMapping(".ivf", "video/x-ivf");
                MimeHelper.AddMimeMapping(".ins", "application/x-internet-signup");
                MimeHelper.AddMimeMapping(".ico", "image/x-icon");
                MimeHelper.AddMimeMapping(".jpg", "image/jpeg");
                MimeHelper.AddMimeMapping(".jfif", "image/pjpeg");
                MimeHelper.AddMimeMapping(".jpe", "image/jpeg");
                MimeHelper.AddMimeMapping(".jpeg", "image/jpeg");
                MimeHelper.AddMimeMapping(".js", "application/x-javascript");
                MimeHelper.AddMimeMapping(".lsx", "video/x-la-asf");
                MimeHelper.AddMimeMapping(".latex", "application/x-latex");
                MimeHelper.AddMimeMapping(".lsf", "video/x-la-asf");
                MimeHelper.AddMimeMapping(".manifest", "application/x-ms-manifest");
                MimeHelper.AddMimeMapping(".mhtml", "message/rfc822");
                MimeHelper.AddMimeMapping(".mny", "application/x-msmoney");
                MimeHelper.AddMimeMapping(".mht", "message/rfc822");
                MimeHelper.AddMimeMapping(".mid", "audio/mid");
                MimeHelper.AddMimeMapping(".mpv2", "video/mpeg");
                MimeHelper.AddMimeMapping(".man", "application/x-troff-man");
                MimeHelper.AddMimeMapping(".mvb", "application/x-msmediaview");
                MimeHelper.AddMimeMapping(".mpeg", "video/mpeg");
                MimeHelper.AddMimeMapping(".m3u", "audio/x-mpegurl");
                MimeHelper.AddMimeMapping(".mdb", "application/x-msaccess");
                MimeHelper.AddMimeMapping(".mpp", "application/vnd.ms-project");
                MimeHelper.AddMimeMapping(".m1v", "video/mpeg");
                MimeHelper.AddMimeMapping(".mpa", "video/mpeg");
                MimeHelper.AddMimeMapping(".me", "application/x-troff-me");
                MimeHelper.AddMimeMapping(".m13", "application/x-msmediaview");
                MimeHelper.AddMimeMapping(".movie", "video/x-sgi-movie");
                MimeHelper.AddMimeMapping(".m14", "application/x-msmediaview");
                MimeHelper.AddMimeMapping(".mpe", "video/mpeg");
                MimeHelper.AddMimeMapping(".mp2", "video/mpeg");
                MimeHelper.AddMimeMapping(".mov", "video/quicktime");
                MimeHelper.AddMimeMapping(".mp3", "audio/mpeg");
                MimeHelper.AddMimeMapping(".mpg", "video/mpeg");
                MimeHelper.AddMimeMapping(".ms", "application/x-troff-ms");
                MimeHelper.AddMimeMapping(".nc", "application/x-netcdf");
                MimeHelper.AddMimeMapping(".nws", "message/rfc822");
                MimeHelper.AddMimeMapping(".oda", "application/oda");
                MimeHelper.AddMimeMapping(".ods", "application/oleobject");
                MimeHelper.AddMimeMapping(".pmc", "application/x-perfmon");
                MimeHelper.AddMimeMapping(".p7r", "application/x-pkcs7-certreqresp");
                MimeHelper.AddMimeMapping(".p7b", "application/x-pkcs7-certificates");
                MimeHelper.AddMimeMapping(".p7s", "application/pkcs7-signature");
                MimeHelper.AddMimeMapping(".pmw", "application/x-perfmon");
                MimeHelper.AddMimeMapping(".ps", "application/postscript");
                MimeHelper.AddMimeMapping(".p7c", "application/pkcs7-mime");
                MimeHelper.AddMimeMapping(".pbm", "image/x-portable-bitmap");
                MimeHelper.AddMimeMapping(".ppm", "image/x-portable-pixmap");
                MimeHelper.AddMimeMapping(".pub", "application/x-mspublisher");
                MimeHelper.AddMimeMapping(".pnm", "image/x-portable-anymap");
                MimeHelper.AddMimeMapping(".png", "image/png");
                MimeHelper.AddMimeMapping(".pml", "application/x-perfmon");
                MimeHelper.AddMimeMapping(".p10", "application/pkcs10");
                MimeHelper.AddMimeMapping(".pfx", "application/x-pkcs12");
                MimeHelper.AddMimeMapping(".p12", "application/x-pkcs12");
                MimeHelper.AddMimeMapping(".pdf", "application/pdf");
                MimeHelper.AddMimeMapping(".pps", "application/vnd.ms-powerpoint");
                MimeHelper.AddMimeMapping(".p7m", "application/pkcs7-mime");
                MimeHelper.AddMimeMapping(".pko", "application/vndms-pkipko");
                MimeHelper.AddMimeMapping(".ppt", "application/vnd.ms-powerpoint");
                MimeHelper.AddMimeMapping(".pmr", "application/x-perfmon");
                MimeHelper.AddMimeMapping(".pma", "application/x-perfmon");
                MimeHelper.AddMimeMapping(".pot", "application/vnd.ms-powerpoint");
                MimeHelper.AddMimeMapping(".prf", "application/pics-rules");
                MimeHelper.AddMimeMapping(".pgm", "image/x-portable-graymap");
                MimeHelper.AddMimeMapping(".qt", "video/quicktime");
                MimeHelper.AddMimeMapping(".ra", "audio/x-pn-realaudio");
                MimeHelper.AddMimeMapping(".rgb", "image/x-rgb");
                MimeHelper.AddMimeMapping(".ram", "audio/x-pn-realaudio");
                MimeHelper.AddMimeMapping(".rmi", "audio/mid");
                MimeHelper.AddMimeMapping(".ras", "image/x-cmu-raster");
                MimeHelper.AddMimeMapping(".roff", "application/x-troff");
                MimeHelper.AddMimeMapping(".rtf", "application/rtf");
                MimeHelper.AddMimeMapping(".rtx", "text/richtext");
                MimeHelper.AddMimeMapping(".sv4crc", "application/x-sv4crc");
                MimeHelper.AddMimeMapping(".spc", "application/x-pkcs7-certificates");
                MimeHelper.AddMimeMapping(".setreg", "application/set-registration-initiation");
                MimeHelper.AddMimeMapping(".snd", "audio/basic");
                MimeHelper.AddMimeMapping(".stl", "application/vndms-pkistl");
                MimeHelper.AddMimeMapping(".setpay", "application/set-payment-initiation");
                MimeHelper.AddMimeMapping(".stm", "text/html");
                MimeHelper.AddMimeMapping(".shar", "application/x-shar");
                MimeHelper.AddMimeMapping(".sh", "application/x-sh");
                MimeHelper.AddMimeMapping(".sit", "application/x-stuffit");
                MimeHelper.AddMimeMapping(".spl", "application/futuresplash");
                MimeHelper.AddMimeMapping(".sct", "text/scriptlet");
                MimeHelper.AddMimeMapping(".scd", "application/x-msschedule");
                MimeHelper.AddMimeMapping(".sst", "application/vndms-pkicertstore");
                MimeHelper.AddMimeMapping(".src", "application/x-wais-source");
                MimeHelper.AddMimeMapping(".sv4cpio", "application/x-sv4cpio");
                MimeHelper.AddMimeMapping(".tex", "application/x-tex");
                MimeHelper.AddMimeMapping(".tgz", "application/x-compressed");
                MimeHelper.AddMimeMapping(".t", "application/x-troff");
                MimeHelper.AddMimeMapping(".tar", "application/x-tar");
                MimeHelper.AddMimeMapping(".tr", "application/x-troff");
                MimeHelper.AddMimeMapping(".tif", "image/tiff");
                MimeHelper.AddMimeMapping(".txt", "text/plain");
                MimeHelper.AddMimeMapping(".texinfo", "application/x-texinfo");
                MimeHelper.AddMimeMapping(".trm", "application/x-msterminal");
                MimeHelper.AddMimeMapping(".tiff", "image/tiff");
                MimeHelper.AddMimeMapping(".tcl", "application/x-tcl");
                MimeHelper.AddMimeMapping(".texi", "application/x-texinfo");
                MimeHelper.AddMimeMapping(".tsv", "text/tab-separated-values");
                MimeHelper.AddMimeMapping(".ustar", "application/x-ustar");
                MimeHelper.AddMimeMapping(".uls", "text/iuls");
                MimeHelper.AddMimeMapping(".vcf", "text/x-vcard");
                MimeHelper.AddMimeMapping(".wps", "application/vnd.ms-works");
                MimeHelper.AddMimeMapping(".wav", "audio/wav");
                MimeHelper.AddMimeMapping(".wrz", "x-world/x-vrml");
                MimeHelper.AddMimeMapping(".wri", "application/x-mswrite");
                MimeHelper.AddMimeMapping(".wks", "application/vnd.ms-works");
                MimeHelper.AddMimeMapping(".wmf", "application/x-msmetafile");
                MimeHelper.AddMimeMapping(".wcm", "application/vnd.ms-works");
                MimeHelper.AddMimeMapping(".wrl", "x-world/x-vrml");
                MimeHelper.AddMimeMapping(".wdb", "application/vnd.ms-works");
                MimeHelper.AddMimeMapping(".wsdl", "text/xml");
                MimeHelper.AddMimeMapping(".xap", "application/x-silverlight-app");
                MimeHelper.AddMimeMapping(".xml", "text/xml");
                MimeHelper.AddMimeMapping(".xlm", "application/vnd.ms-excel");
                MimeHelper.AddMimeMapping(".xaf", "x-world/x-vrml");
                MimeHelper.AddMimeMapping(".xla", "application/vnd.ms-excel");
                MimeHelper.AddMimeMapping(".xls", "application/vnd.ms-excel");
                MimeHelper.AddMimeMapping(".xlsx", "application/vnd.ms-excel");
                MimeHelper.AddMimeMapping(".xof", "x-world/x-vrml");
                MimeHelper.AddMimeMapping(".xlt", "application/vnd.ms-excel");
                MimeHelper.AddMimeMapping(".xlc", "application/vnd.ms-excel");
                MimeHelper.AddMimeMapping(".xsl", "text/xml");
                MimeHelper.AddMimeMapping(".xbm", "image/x-xbitmap");
                MimeHelper.AddMimeMapping(".xlw", "application/vnd.ms-excel");
                MimeHelper.AddMimeMapping(".xpm", "image/x-xpixmap");
                MimeHelper.AddMimeMapping(".xwd", "image/x-xwindowdump");
                MimeHelper.AddMimeMapping(".xsd", "text/xml");
                MimeHelper.AddMimeMapping(".z", "application/x-compress");
                MimeHelper.AddMimeMapping(".zip", "application/x-zip-compressed");
                MimeHelper.AddMimeMapping(".*", "application/octet-stream");
            }
   }

      
    
}
