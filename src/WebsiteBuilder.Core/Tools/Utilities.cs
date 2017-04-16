using System;
using System.IO;
using WebsiteBuilder.Interface.Compiling;

namespace WebsiteBuilder.Core.Tools {
    static class Utilities {

        public static readonly ICompiler JavaScriptMinifier = new MicrosoftMinifier(MicrosoftMinifier.Mode.JavaScript);

		public static readonly ICompiler CssMinifier = new MicrosoftMinifier(MicrosoftMinifier.Mode.CSS);

		public static readonly ICompiler LessCompiler = new DotLessCompiler();

        public static String FullToRelativePath(String fullPath, Project project) {
            if (project == null && project.ProjectFile == null || !project.ProjectFile.Exists) {
                return fullPath;
            }

            return FullToRelativePath(fullPath, project.ProjectFile.DirectoryName);
        }

        public static String FullToRelativePath(String fullPath, String directoryPath) {
            if (!Path.IsPathRooted(fullPath) || !fullPath.StartsWith(directoryPath)) {
                return fullPath;
            }

            return fullPath.Substring(directoryPath.Length + 1);
        }

        public static String RelativeToFullPath(String relativePath, Project project) {
            if (project == null && project.ProjectFile == null || !project.ProjectFile.Exists) {
                return relativePath;
            }

            return RelativeToFullPath(relativePath, project.ProjectFile.DirectoryName);
        }

        public static String RelativeToFullPath(String relativePath, String directoryPath) {
            if (Path.IsPathRooted(relativePath)) {
                return relativePath;
            }

            return Path.Combine(directoryPath, relativePath);
        }
    }
}
