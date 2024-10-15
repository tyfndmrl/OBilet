namespace OBilet.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class NonSessionAttribute : Attribute
    {
        public NonSessionAttribute() { }
    }
}
