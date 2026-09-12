using System;

namespace Ourogen.Templates.Sample
{
    internal class ObjectExampleTemplate
    {
        
        #region @remove
        public void Remove()
        {

        }
        #endregion

        #region @replace #Object.ReplaceText
        public string Replace()
        {
            return "ReplaceText";
        }
        #endregion

        #region @if #Object.?True
        public bool True()
        {
            return true;
        }
        #endregion

        #region @if not #Object.?True
        public bool NotTrue()
        {
            return true;
        }
        #endregion
        
        #region @if #Object.?False
        public bool False()
        {
            return false;
        }
        #endregion

        #region @foreach #ForEachObject in #ForEachObjects[]
        #region @replace #ForEachObject.Type, #ForEachObject.Name, #ForEachObject.Value:"null"
        public Type Name { get; set; } = null;
        #endregion
        #endregion
    }
}