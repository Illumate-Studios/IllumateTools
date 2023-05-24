namespace IllumateStudios.URP
{
    public class PostPreRenderer
    {
        internal static PostPreRenderables PPRenderables = new();

        public static void Add(IPostPreRendered postPreRendered)
        {
            PPRenderables.Add(postPreRendered);
        }
        public static void Remove(IPostPreRendered postPreRendered)
        {
            PPRenderables.Remove(postPreRendered);
        }
    }
}
