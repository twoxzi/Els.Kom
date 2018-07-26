using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Els.KOM.Stage
{
    public class KomChildEntityCollection : IList<KomChildEntity>
    {

        protected List<KomChildEntity> EntityList = new List<KomChildEntity>();
        protected HashSet<String> EntityHashSet = new HashSet<string>();
        protected static void CheckItemName(KomChildEntity item)
        {
            if(String.IsNullOrWhiteSpace(item.Name))
            {
                throw new Exception($"{nameof(item.Name)} could not be NullOrWhiteSpace");
            }
        }
        protected void ConflictItemByName(KomChildEntity item)
        {
            if(EntityHashSet.Contains(item.Name))
            {
                throw new Exception($"already exists File:{item.Name}");
            }
        }

        public KomChildEntity this[Int32 index]
        {
            get
            {
                return EntityList[index];
            }

            set
            {
                var item = EntityList[index];
                CheckItemName(value);
                ConflictItemByName(value);
                EntityHashSet.Remove(item.Name);
                EntityHashSet.Add(value.Name);
                EntityList[index] = value;
            }
        }

        public Int32 Count
        {
            get
            {
                return EntityList.Count;
            }
        }

        public Boolean IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(KomChildEntity item)
        {
            CheckItemName(item);
            ConflictItemByName(item);
            if(EntityHashSet.Add(item.Name))
            {
                EntityList.Add(item);
            }
        }




        public void Clear()
        {
            EntityHashSet.Clear();
            EntityList.Clear();

        }

        public Boolean Contains(KomChildEntity item)
        {
            return EntityHashSet.Contains(item.Name);
        }

        public void CopyTo(KomChildEntity[] array, Int32 arrayIndex)
        {
            EntityList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KomChildEntity> GetEnumerator()
        {
            return EntityList.GetEnumerator();
        }

        public Int32 IndexOf(KomChildEntity item)
        {
            for(int i = 0; i < EntityList.Count; i++)
            {
                if(item.Name == EntityList[i].Name)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(Int32 index, KomChildEntity item)
        {
            CheckItemName(item);
            ConflictItemByName(item);
            EntityList.Insert(index, item);
        }

        public Boolean Remove(KomChildEntity item)
        {
            CheckItemName(item);
            EntityHashSet.Remove(item.Name);
            Int32 i = IndexOf(item);
            if(i > 0)
            {
                EntityList.RemoveAt(i);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(Int32 index)
        {
            KomChildEntity item = EntityList[index];
            EntityHashSet.Remove(item.Name);
            EntityList.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return EntityList.GetEnumerator();
        }
    }
}
