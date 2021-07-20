using System.Collections.Generic;

namespace WebStore.ViewModels
{
    public class SelectableSectionsViewModel
    {
        public IEnumerable<SectionViewModel> Sections { get; init; }

        public int? SectionId { get; init; }

        public int? ParentSectionId { get; init; }
    }
}