using MPT.CSI.API.Core.Helpers;
using MPT.CSI.API.Core.Support;

namespace MPT.CSI.API.Core.Program.ModelBehavior.Definition
{
    /// <summary>
    /// Represents the generalized displacements in the application.
    /// </summary>
    public class GeneralizedDisplacements : CSiApiBase, IChangeableName, ICountable, IDeletable, IListableNames
    {
        #region Initialization        
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralizedDisplacements"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public GeneralizedDisplacements(CSiApiSeed seed) : base(seed) { }

        #endregion

        #region Methods: Interface
        /// <summary>
        /// This function changes the name of an existing generalized displacement.
        /// </summary>
        /// <param name="currentName">The existing name of a defined generalized displacement.</param>
        /// <param name="newName">The new name for the generalized displacement.</param>
        public void ChangeName(string currentName, string newName)
        {
            _callCode = _sapModel.GDispl.ChangeName(currentName, newName);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function returns the total number of defined generalized displacements in the model.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _sapModel.GDispl.Count();
        }

        /// <summary>
        /// The function deletes a specified generalized displacement.
        /// </summary>
        /// <param name="name">The name of an existing generalized displacement.</param>
        public void Delete(string name)
        {
            _callCode = _sapModel.GDispl.Delete(name);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function retrieves the names of all defined generalized displacements.
        /// </summary>
        /// <param name="numberOfNames">The number of generalized displacement names retrieved by the program.</param>
        /// <param name="names">Generalized displacement names retrieved by the program.</param>
        public void GetNameList(ref int numberOfNames, ref string[] names)
        {
            _callCode = _sapModel.GDispl.GetNameList(ref numberOfNames, ref names);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }


        #endregion

        #region Methods: Public


        /// <summary>
        /// This function retrieves the total number of point objects included in a specified generalized displacement.
        /// </summary>
        /// <param name="name">The name of an existing generalized displacement.</param>
        /// <param name="count">The number of point objects included in the specified generalized displacement.</param>
        public void CountPoint(string name,
            ref int count)
        {
            _callCode = _sapModel.GDispl.CountPoint(name, ref count);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        /// <summary>
        /// This function deletes one point object from a generalized displacement definition.
        /// </summary>
        /// <param name="nameDisplacement">The name of an existing generalized displacement.</param>
        /// <param name="namePoint">The name of a point object included in the generalized displacement that is to be deleted.</param>
        public void DeletePoint(string nameDisplacement,
            string namePoint)
        {
            _callCode = _sapModel.GDispl.DeletePoint(nameDisplacement, namePoint);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }



        // === Get/Set
        /// <summary>
        /// This function retrieves the point objects and their scale factors from a generalized displacement definition.
        /// </summary>
        /// <param name="name">The name of an existing generalized displacement.</param>
        /// <param name="numberItems">The number of point objects included in the generalized displacement definition.</param>
        /// <param name="pointNames">The names of the point objects included in the generalized displacement definition.</param>
        /// <param name="scaleFactors">The unitless scale factors for each of the displacement degrees of freedom of the associated point objects that are included in the generalized displacement definition.</param>
        public void GetPoint(string name,
            ref int numberItems,
            ref string[] pointNames,
            ref Deformations[] scaleFactors)
        {
            double[] U1 = new double[0];
            double[] U2 = new double[0];
            double[] U3 = new double[0];
            double[] R1 = new double[0];
            double[] R2 = new double[0];
            double[] R3 = new double[0];

            _callCode = _sapModel.GDispl.GetPoint(name, ref numberItems, ref pointNames, ref U1, ref U2, ref U3, ref R1, ref R2, ref R3);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            scaleFactors = new Deformations[U1.Length + 1];
            for (int i = 0; i < U1.Length; i++)
            {
                scaleFactors[i].U1 = U1[i];
                scaleFactors[i].U2 = U2[i];
                scaleFactors[i].U3 = U3[i];
                scaleFactors[i].R1 = R1[i];
                scaleFactors[i].R2 = R2[i];
                scaleFactors[i].R3 = R3[i];
            }
        }

        /// <summary>
        /// This function adds a point object and its scale factors to a generalized displacement definition. , or, i
        /// If the point object already exists in the generalized displacement definition, it modifies the scale factors.
        /// </summary>
        /// <param name="name">The name of an existing generalized displacement.</param>
        /// <param name="pointName">The name of a point object to be included in the generalized displacement definition.</param>
        /// <param name="scaleFactors">Unitless scale factors for the point object displacement degrees of freedom.</param>
        public void SetPoint(string name,
            string pointName,
            Deformations scaleFactors)
        {
            double[] csiScaleFators = scaleFactors.ToArray();
            _callCode = _sapModel.GDispl.SetPoint(name, pointName, ref csiScaleFators);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }

        // ===

        /// <summary>
        /// This function retrieves the generalized displacement type.
        /// </summary>
        /// <param name="name">The name of an existing generalized displacement.</param>
        /// <param name="type">The generalized displacement type.</param>
        public void GetType(string name,
            ref eGeneralizedDisplacementType type)
        {
            int csiType = 0;

            _callCode = _sapModel.GDispl.GetTypeOAPI(name, ref csiType);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }

            type = (eGeneralizedDisplacementType)csiType;
        }

        /// <summary>
        /// This function sets the generalized displacement type.
        /// </summary>
        /// <param name="name">The name of an existing generalized displacement.</param>
        /// <param name="type">The generalized displacement type.</param>
        public void SetType(string name,
            eGeneralizedDisplacementType type)
        {
            _callCode = _sapModel.GDispl.SetTypeOAPI(name, (int)type);
            if (throwCurrentApiException(_callCode)) { throw new CSiException(); }
        }
        #endregion
    }
}
