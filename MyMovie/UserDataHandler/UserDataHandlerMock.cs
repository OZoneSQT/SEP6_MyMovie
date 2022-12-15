using System.Collections;

namespace MyMovie.UserDataHandler
{
    public class UserDataHandlerMock : IUserDataHandler
    {
        public void ClearData(string userName)
        {
            throw new System.NotImplementedException();
        }

        public void DropDataEntry(string userName, int itemId, string timeStamp)
        {
            throw new System.NotImplementedException();
        }

        public void DropDataFromList(string userName, string listName, int itemId)
        {
            throw new System.NotImplementedException();
        }

        public void DropList(string userName, string listName)
        {
            throw new System.NotImplementedException();
        }

        public int GetItemCountScore(string userName)
        {
            throw new System.NotImplementedException();
        }

        public ItemModel GetItemData(int itemId)
        {
            throw new System.NotImplementedException();
        }

        public TopModel GetItemRating(string category, int n)
        {
            throw new System.NotImplementedException();
        }

        public TopModel GetItemRating(int n)
        {
            throw new System.NotImplementedException();
        }

        public ArrayList GetListData(string userName)
        {
            throw new System.NotImplementedException();
        }

        public void PutData(string userName, string listName, int itemId, string comment)
        {
            throw new System.NotImplementedException();
        }
    }
}
