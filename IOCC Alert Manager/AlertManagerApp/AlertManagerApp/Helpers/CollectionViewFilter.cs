using System.Data;

namespace AlertManagerApp.Helpers
{
    public class ViewFilter
    {
        // ** fields  
        System.ComponentModel.ICollectionView _view;
        string _filterExpression;
        DataTable _dt;

        // ** ctor  
        public ViewFilter(System.ComponentModel.ICollectionView view)
        {
            _view = view;
        }

        // ** object model  
        public string FilterExpression
        {
            get { return _filterExpression; }
            set
            {
                _filterExpression = value;
                UpdateFilter();
                _view.Filter = null;
                if (!string.IsNullOrEmpty(_filterExpression))
                {
                    _view.Filter = FilterPredicate;
                }
            }
        }

        // ** implementation  
        bool FilterPredicate(object obj)
        {
            // populate the row  
            var row = _dt.Rows[0];
            foreach (var pi in obj.GetType().GetProperties())
            {
                row[pi.Name] = pi.GetValue(obj, null);
            }

            // compute the expression  
            return (bool)row["_filter"];
        }
        void UpdateFilter()
        {
            _dt = null;
            if (\_view.CurrentItem != null && !string.IsNullOrEmpty(\_filterExpression))  
            {
                // build/rebuild data table  
                var dt = new DataTable();
                foreach (var pi in _view.CurrentItem.GetType().GetProperties())
                {
                    dt.Columns.Add(pi.Name, pi.PropertyType);
                }

                // add calculated column  
                dt.Columns.Add("\_filter", typeof(bool), \_filterExpression);

                // create a single row for evaluating expressions  
                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add(dt.NewRow());
                }

                // done, save table  
                _dt = dt;
            }
        }
    }
}
