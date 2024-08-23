namespace _3DBrushCode.Logic.Contexts {
    public class RootContext {
        public GlobalContext GlobalContext;
        public UnityContext UnityContext;
        
        public RootContext() {
            GlobalContext = new GlobalContext();
            UnityContext = new UnityContext();
        }
    }
}
