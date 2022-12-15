using System.Collections;

namespace MyMovie.UserDataHandler
{
    public interface IUserDataHandler
    {
        // Add item to list
        void PutData(string userName, string listName, int itemId, string comment);
        
        // Drop item entry
        void DropDataEntry(string userName, int itemId, string timeStamp);

        // Drop item from list
        void DropDataFromList(string userName, string listName, int itemId);

        // Drop list
        void DropList(string userName, string listName);

        // Drop users data 
        void ClearData(string userName);

        // Get item data
        ItemModel GetItemData(int itemId);

        // Get users lists IDs
        ArrayList GetListData(string userName);

        // Get user score
        int GetItemCountScore(string userName);

        // Get rating
        TopModel GetItemRating(string category, int n);

    }
}
