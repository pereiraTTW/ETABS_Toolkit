/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2018, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Common;
using BH.oM.Structure.Results;

namespace BH.Adapter.ETABS
{
    public partial class ETABSAdapter
    {

        protected override IEnumerable<IResult> ReadResults(Type type, IList ids = null, IList cases = null, int divisions = 5)
        {
            IEnumerable<IResult> results = new List<IResult>();

            if (typeof(StructuralGlobalResult).IsAssignableFrom(type))
                results = GetGlobalResults(type, cases);
            else
                results = GetObjectResults(type, ids, cases, divisions);

            return results;

            

        }

        private IEnumerable<IResult> GetGlobalResults(Type type, IList cases)
        {
            if (typeof(GlobalReactions).IsAssignableFrom(type))
                return GetGlobalReactions(cases);
            if (typeof(ModalDynamics).IsAssignableFrom(type))
                throw new NotImplementedException("modal dynamics not supported yet");

            return new List<IResult>();

        }

        private IEnumerable<IResult> GetGlobalReactions(IList cases)
        {


            return new List<IResult>();

        }

        private IEnumerable<IResult> GetObjectResults(Type type, IList ids = null, IList cases = null, int divisions = 5)
        {
            IEnumerable<IResult> results = new List<IResult>();

            if (typeof(NodeResult).IsAssignableFrom(type))
                results = GetNodeResults(type, ids, cases);
            else if (typeof(BarResult).IsAssignableFrom(type))
                results = GetBarResults(type, ids, cases, divisions);
            else if (typeof(MeshResult).IsAssignableFrom(type))
                results = GetMeshResults(type, ids, cases, divisions);
            //else
            //    return new List<IResult>();

            return results;
        }

        private IEnumerable<IResult> GetNodeResults(Type type, IList ids = null, IList cases = null)
        {
            IEnumerable<IResult> results = new List<NodeResult>();

            if (type == typeof(NodeAcceleration))
                results = Helper.GetNodeAcceleration(m_model, ids, cases);
            else if (type == typeof(NodeDisplacement))
                results = Helper.GetNodeDisplacement(m_model, ids, cases);
            else if (type == typeof(NodeReaction))
                results = Helper.GetNodeReaction(m_model, ids, cases);
            else if (type == typeof(NodeVelocity))
                results = Helper.GetNodeVelocity(m_model, ids, cases);

            return results;
        }

        private IEnumerable<IResult> GetBarResults(Type type, IList ids = null, IList cases = null, int divisions = 5)
        {
            IEnumerable<BarResult> results = new List<BarResult>();

            if (type == typeof(BarDeformation))
                results = Helper.GetBarDeformation(m_model, ids, cases, divisions);
            else if (type == typeof(BarForce))
                results = Helper.GetBarForce(m_model, ids, cases, divisions);
            else if (type == typeof(BarStrain))
                results = Helper.GetBarStrain(m_model, ids, cases, divisions);
            else if (type == typeof(BarStress))
                results = Helper.GetBarStress(m_model, ids, cases, divisions);

            return results;
        }

        private IEnumerable<IResult> GetMeshResults(Type type, IList ids = null, IList cases = null, int divisions = 5)
        {
            IEnumerable<MeshResult> results = new List<MeshResult>();

            if (type == typeof(MeshForce))
                results = Helper.GetMeshForce(m_model, ids, cases, divisions);
            else if (type == typeof(MeshStress))
                results = Helper.GetMeshStress(m_model, ids, cases, divisions);

            return results;
        }

    }
}
