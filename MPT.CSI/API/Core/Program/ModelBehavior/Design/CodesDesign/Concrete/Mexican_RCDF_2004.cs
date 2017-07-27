using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Design.CodesDesign.Concrete
{
#if !BUILD_CSiBridgev18 && !BUILD_CSiBridgev19
    /// <summary>
    /// Concrete design code <see cref="Mexican_RCDF_2004"/>.
    /// </summary>
    /// <seealso cref="MPT.CSI.API.Core.Support.CSiApiBase" />
    public class Mexican_RCDF_2004 : CSiApiBase
    {
#region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="Mexican_RCDF_2004"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public Mexican_RCDF_2004(CSiApiSeed seed) : base(seed) { }


#endregion

#region Methods: Public
        /// <summary>
        /// This function retrieves the value of a concrete design overwrite item.
        /// </summary>
        /// <param name="name">The name of a frame object with a concrete frame design procedure.</param>
        /// <param name="item">The overwrite item considered.</param>
        /// <param name="value">The value of the considered overwrite item.</param>
        /// <param name="programDetermined">True: The specified value is program determined.</param>
        /// <exception cref="CSiException"></exception>
        public void GetOverwrite(string name,
            int item,
            ref double value,
            ref bool programDetermined)
        {           
            _callCode = _sapModel.DesignConcrete.Mexican_RCDF_2004.GetOverwrite(name, (int)item, ref value, ref programDetermined);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }            
        }

        /// <summary>
        /// This function sets the value of a concrete design overwrite item.
        /// </summary>
        /// <param name="name">The name of an existing frame object or group, depending on the value of the <paramref name="itemType"/> item.</param>
        /// <param name="item">The overwrite item considered.</param>
        /// <param name="value">The value of the considered overwrite item.</param>
        /// <param name="itemType">If this item is <see cref="eItemType.Object" />, the assignment is made to the frame object specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.Group" />, the assignment is made to all frame objects in the group specified by the <paramref name="name"/> item.
        /// If this item is <see cref="eItemType.SelectedObjects" />, assignment is made to all selected frame objects, and the <paramref name="name"/> item is ignored.</param>
        /// <exception cref="CSiException"></exception>
        public void SetOverwrite(string name,
            int item,
            double value,
            eItemType itemType = eItemType.Object)
        {
            _callCode = _sapModel.DesignConcrete.Mexican_RCDF_2004.SetOverwrite(name, (int)item, value, CSiEnumConverter.ToCSi(itemType));
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }




        /// <summary>
        /// This function retrieves the value of a concrete design preference item.
        /// </summary>
        /// <param name="item">The preference item considered.</param>
        /// <param name="value">The value of the considered preference item.</param>
        /// <exception cref="CSiException"></exception>
        public void GetPreference(int item,
            ref double value)
        {           
            _callCode = _sapModel.DesignConcrete.Mexican_RCDF_2004.GetPreference((int)item, ref value);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }            
        }

        /// <summary>
        /// This function sets the value of a concrete design preference item.
        /// </summary>
        /// <param name="item">The preference item considered.</param>
        /// <param name="value">The value of the considered preference item.</param>
        /// <exception cref="CSiException"></exception>
        public void SetPreference(int item,
            double value)
        {
            _callCode = _sapModel.DesignConcrete.Mexican_RCDF_2004.SetPreference((int)item, value);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
#endregion
    }
#endif
}
