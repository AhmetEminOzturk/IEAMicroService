namespace IEAMicroService.WebUI.Dtos.CategoryDto
{
    public class UpdateCategoryDto
    {
        public Data[] data { get; set; }

        public class Data
        {
            public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
    }
}
