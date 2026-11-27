namespace GestorTareas;

public static class TaskValidator
{
    public static string? Validate(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title)) return "El título es obligatorio.";
        if (title.Trim().Length > 60) return "El título admite máximo 60 caracteres.";
        if (description.Trim().Length > 200) return "La descripción admite máximo 200 caracteres.";
        return null;
    }
}
