namespace Helper
{
    public static class MessageGeneral
    {
        private static string messageDontExist = "The Id  Doesn't exist.";
        private static string messageDeleteSuccess = "The comment was deleted with success.";
        private static string messageGetCategoryNotExist = "The category doesn't exists.";
        public static string DontExist { get => messageDontExist; set { messageDontExist = value; } }
        public static string DeleteSuccess { get => messageDeleteSuccess; set { messageDeleteSuccess = value; } }
        public static string CategoryDontExist { get => messageGetCategoryNotExist; set { messageGetCategoryNotExist = value; } }
    }
}
