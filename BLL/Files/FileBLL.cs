using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.BLL.Files
{
    public class FileBLL
    {

        public string UploadFile(byte[] f, string Session, string fileext, string PatientName)
        {
            // the byte array argument contains the content of the file
            // the string argument contains the name and extension
            // of the file passed in the byte array
            var name = Globals.Globals.AuthSessions[Session].EmployeeName;


                try
                {
                    var selectFolder = CreateNew("", "");
                    string lastFolderName = Path.GetFileName/*(Path.GetDirectoryName*/(selectFolder);
                    // instance a memory stream and pass the
                    // byte array to its constructor
                    MemoryStream ms = new MemoryStream(f);

                    var result = Path.ChangeExtension(PatientName, fileext);
                    // instance a filestream pointing to the 
                    // storage folder, use the original file name
                    var fullName = result+ PatientName+"."+fileext;

                FileStream fs = new FileStream
                    (selectFolder + (@"/Files/"/* + lastFolderName + "/"*/) + fullName, FileMode.Create);

                    ms.WriteTo(fs);
                    // clean up
                    ms.Close();
                    fs.Close();
                    fs.Dispose();

                    string[] filePaths = Directory.GetFiles(selectFolder + (@"/Files/"/* + lastFolderName + "/"*/));



                    foreach (string file in filePaths)
                    {
                        var a = Path.GetFileName(file);
                        if (a == result)
                        {
                            return file;
                        }
                    }

                    throw new Exception("file not found");

                    // return OK if we made it this far

                }
                catch (Exception ex)
                {
                    // return the error message if the operation fails
                    return ex.Message.ToString();
                }
            }
        

        public static string CreateNew(string folderType, string ext)
        {
            string SAMS = @"C:\inetpub\wwwroot\SAMS\Files\"; /*C:\Users\Noel\Desktop\brandon\ddf latest\STRAUSSDDF\STRAUSSDDF\Swagger*/    
           
                var check = EnsurePathExists(SAMS);
                return check;
           

        }
        public static string EnsurePathExists(string path)
        {
            // ... Set to folder path we must ensure exists.
            try
            {
                // ... If the directory doesn't exist, create it.
                if (!Directory.Exists(path))
                {
                    var folder = Directory.CreateDirectory(path);
                    return folder.FullName;
                }
                else
                {
                    return path;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                // Fail silently.
            }
        }

    }
}
