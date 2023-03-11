namespace MP.WebApi.Models.Responses
{
   
    /// <typeparam name="T"></typeparam>
    public class ItemResponse<T> : SuccessResponse, IItemResponse
    {
        public T Item { get; set; }

        object IItemResponse.Item { get { return this.Item; } }
    }
}
