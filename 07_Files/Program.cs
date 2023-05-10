using System.Security;
using System.Text;

namespace _07_Files
{
    internal class Program
    {
        // Practice 1.1
        static void CopyDataByStream(string sourceFileName, string destinationFileName)
        {
            using var streamReader = new StreamReader(sourceFileName);
            string text = streamReader.ReadToEnd();
            using var streamWriter = new StreamWriter(destinationFileName);
            streamWriter.Write(text);
        }
        // Practice 1.2
        static void CopyDataByFile(string sourceFileName, string destinationFileName)
        {
            string text = File.ReadAllText(sourceFileName);
            File.WriteAllText(destinationFileName, text);
        }
        static string BytesToString(long byteCount)
        {
            string[] sufix = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0)
                return "0" + sufix[0];
            long bytes = Math.Abs(byteCount);
            int index = Convert.ToInt32(Math.Floor(Math.Log(Math.Abs(byteCount), 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, index), 1);
            return $"{Math.Sign(byteCount) * num:0.##}{sufix[index]}";
        }

        static long GetDirectorySize(DirectoryInfo directoryInfo)
        {
            long size = 0;
            try
            {
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    size += file.Length;
                }
                foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
                {
                    size += GetDirectorySize(directory);
                }
            }
            catch (Exception)
            {
                return size;
            }
            return size;
        }
        // Practice 2
        static void CollectDiscInformation(string driveName)
        {
            var driveInfo = new DriveInfo(driveName);
            if (driveInfo.IsReady)
            {
                var stringBuilder = new StringBuilder();
                var driveDirectory = driveInfo.RootDirectory;
                foreach (var file in driveDirectory.GetFiles())
                {
                    string line = $"{file.Name}, {file.Attributes}, {BytesToString(file.Length)}";
                    stringBuilder.AppendLine(line);
                }
                foreach (var directory in driveDirectory.GetDirectories())
                {
                    string line = $"{directory.Name}, {directory.Attributes}, {BytesToString(GetDirectorySize(directory))}";
                    stringBuilder.AppendLine(line);
                }
                File.WriteAllText($@"{CurrentDirectory}\Directory{driveInfo.Name[0]}.txt", stringBuilder.ToString());
            }
        }
        // Practice 3
        static void ReadAllFiles(DirectoryInfo directory)
        {
            foreach (var file in directory.GetFiles())
            {
                try
                {
                    string fileContent = File.ReadAllText(file.FullName);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(file.FullName);
                    Console.ResetColor();
                    Console.WriteLine(string.IsNullOrEmpty(fileContent) ? "[empty file]" : $"{File.ReadAllText(file.FullName)}");
                }
                catch (Exception) { }
            }
        }
        static void ReadAllFilesByPath(string path)
        {
            ReadAllFiles(new DirectoryInfo(path));
        }
        static string? CurrentDirectory = new DirectoryInfo(Environment.CurrentDirectory)?.Parent?.Parent?.Parent?.FullName;
        static void Main(string[] args)
        {
            string sourceFile = @$"{CurrentDirectory ?? "."}\data.txt";
            string destinationFile = @$"{CurrentDirectory ?? "."}\rez.txt";

            try
            {
                CopyDataByStream(sourceFile, destinationFile);
                CopyDataByFile(sourceFile, destinationFile);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"The file '{ex.FileName}' was not found.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An I/O error occurred: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access to the file is denied: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            try
            {
                CollectDiscInformation(@"3");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"The file '{ex.FileName}' was not found.");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Directory not found: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An I/O error occurred: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access to the file is denied: {ex.Message}");
            }
            catch (SecurityException ex)
            {
                Console.WriteLine($"Security error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            try
            {
                ReadAllFilesByPath(@"C:\");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"The file '{ex.FileName}' was not found.");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Directory not found: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An I/O error occurred: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access to the file is denied: {ex.Message}");
            }
            catch (SecurityException ex)
            {
                Console.WriteLine($"Security error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            // Task 1
            Dictionary<string, string> phones = new Dictionary<string, string>();
            using (var streamReader = new StreamReader($@"{CurrentDirectory ?? "."}\phones.txt"))
            {
                string? line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] fields = line.Split('-');
                    string personName = fields[0];
                    string phoneNumber = fields[1];
                    phones[personName] = phoneNumber;
                };
            }

            // Task 2
            Console.Write("Enter person name: ");
            string name = Console.ReadLine();
            Console.WriteLine(phones.ContainsKey(name) ? phones[name] : "Invalid person name");

            // Task 3
            using (var streamWriter = new StreamWriter($@"{CurrentDirectory ?? "."}\New.txt"))
            {
                foreach (var phone in phones.Select(p => new KeyValuePair<string, string>(p.Key, p.Value)))
                {
                    streamWriter.WriteLine($"{phone.Key}-" +
                        $"{(phone.Value.StartsWith("80") ? "+380" + phone.Value.Substring(2) : phone.Value)}");
                }
            }
        }
    }
}