using System;
using System.Reflection;

namespace TranDieuSuong_5101_C1_W2021.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}