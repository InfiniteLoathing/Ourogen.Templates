using System.Collections.Generic;

namespace Ourogen.Templates.Sample
{
    internal class ExampleTemplate
    {
        #region @remove
        public void Remove()
        {

        }
        #endregion

        #region @replace ReplaceText
        public string Replace()
        {
            return "ReplaceText";
        }
        #endregion

        #region @if ?True
        public bool True()
        {
            return true;
        }
        #endregion
        
        #region @if ?False
        public bool False()
        {
            return false;
        }
        #endregion

        public IEnumerable<string> ForEach()
        {
            #region @foreach ForEachText in ForEachTexts[]
            yield return "ForEachText";
            #endregion
        }
    }
}