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

using BH.oM.Structure.Properties;
using BH.Engine.Structure;
using ETABS2016;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Engine.ETABS
{
    //public static partial class Convert
    //{
    //    public static ISectionProperty GetSectionProperty(ModelData modelData, string propertyName, eFramePropType propertyType)
    //    {
    //        if (modelData.sectionDict.ContainsKey(propertyName))
    //            return modelData.sectionDict[propertyName];

    //        ISectionProperty bhSectionProperty = null;
    //        ISectionDimensions dimensions = null;
    //        string materialName = "";

    //        string fileName = "";
    //        double t3 = 0;
    //        double t2 = 0;
    //        double tf = 0;
    //        double tw = 0;
    //        double tfb = 0;
    //        double t2b = 0;
    //        int colour = 0;
    //        string notes = "";
    //        string guid = "";

    //        double Area, As2, As3, Torsion, I22, I33, S22, S33, Z22, Z33, R22, R33;
    //        Area = As2 = As3 = Torsion = I22 = I33 = S22 = S33 = Z22 = Z33 = R22 = R33 = 0;

    //        string constructSelector = "fromDimensions";


    //        #region long switch on section property type
    //        switch (propertyType)
    //        {
    //            case eFramePropType.I:
    //                modelData.model.PropFrame.GetISection(propertyName, ref fileName, ref materialName, ref t3, ref t2, ref tf, ref tw, ref t2b, ref tfb, ref colour, ref notes, ref guid);
    //                if (t2 == t2b)
    //                    dimensions = new StandardISectionDimensions(t3, t2, tw, tf, 0, 0);
    //                else
    //                    dimensions = new FabricatedISectionDimensions(t3, t2, t2b, tw, tf, tfb, 0);
    //                break;
    //            case eFramePropType.Channel:
    //                modelData.model.PropFrame.GetChannel(propertyName, ref fileName, ref materialName, ref t3, ref t2, ref tf, ref tw, ref colour, ref notes, ref guid);
    //                dimensions = new StandardChannelSectionDimensions(t3, t2, tw, tf, 0, 0);
    //                break;
    //            case eFramePropType.T:
    //                break;
    //            case eFramePropType.Angle:
    //                break;
    //            case eFramePropType.DblAngle:
    //                modelData.model.PropFrame.GetAngle(propertyName, ref fileName, ref materialName, ref t3, ref t2, ref tf, ref tw, ref colour, ref notes, ref guid);
    //                dimensions = new StandardAngleSectionDimensions(t3, t2, tw, tf, 0, 0);
    //                break;
    //            case eFramePropType.Box:
    //                modelData.model.PropFrame.GetTube(propertyName, ref fileName, ref materialName, ref t3, ref t2, ref tf, ref tw, ref colour, ref notes, ref guid);
    //                if (tf == tw)
    //                    dimensions = new StandardBoxDimensions(t3, t2, tf, 0, 0);
    //                else
    //                    dimensions = new FabricatedBoxDimensions(t3, t2, tw, tf, tf, 0);
    //                break;
    //            case eFramePropType.Pipe:
    //                modelData.model.PropFrame.GetPipe(propertyName, ref fileName, ref materialName, ref t3, ref tw, ref colour, ref notes, ref guid);
    //                dimensions = new TubeDimensions(t3, tw);
    //                break;
    //            case eFramePropType.Rectangular:
    //                modelData.model.PropFrame.GetRectangle(propertyName, ref fileName, ref materialName, ref t3, ref t2, ref colour, ref notes, ref guid);
    //                dimensions = new RectangleSectionDimensions(t3, t2, 0);
    //                break;
    //            case eFramePropType.Circle:
    //                modelData.model.PropFrame.GetCircle(propertyName, ref fileName, ref materialName, ref t3, ref colour, ref notes, ref guid);
    //                dimensions = new CircleDimensions(t3);
    //                break;
    //            case eFramePropType.General:
    //                //this looks to return enough infor for explicitSection() !
    //                constructSelector = "explicit";
    //                modelData.model.PropFrame.GetGeneral(propertyName, ref fileName, ref materialName, ref t3, ref t2, ref Area, ref As2, ref As3, ref Torsion, ref I22, ref I33, ref S22, ref S33, ref Z22, ref Z33, ref R22, ref R33, ref colour, ref notes, ref guid);
    //                break;
    //            case eFramePropType.DbChannel:
    //                break;
    //            case eFramePropType.Auto:
    //                break;
    //            case eFramePropType.SD:
    //                break;
    //            case eFramePropType.Variable:
    //                break;
    //            case eFramePropType.Joist:
    //                break;
    //            case eFramePropType.Bridge:
    //                break;
    //            case eFramePropType.Cold_C:
    //                break;
    //            case eFramePropType.Cold_2C:
    //                break;
    //            case eFramePropType.Cold_Z:
    //                break;
    //            case eFramePropType.Cold_L:
    //                break;
    //            case eFramePropType.Cold_2L:
    //                break;
    //            case eFramePropType.Cold_Hat:
    //                break;
    //            case eFramePropType.BuiltupICoverplate:
    //                break;
    //            case eFramePropType.PCCGirderI:
    //                break;
    //            case eFramePropType.PCCGirderU:
    //                break;
    //            case eFramePropType.BuiltupIHybrid:
    //                break;
    //            case eFramePropType.BuiltupUHybrid:
    //                break;
    //            case eFramePropType.Concrete_L:
    //                break;
    //            case eFramePropType.FilledTube:
    //                break;
    //            case eFramePropType.FilledPipe:
    //                break;
    //            case eFramePropType.EncasedRectangle:
    //                break;
    //            case eFramePropType.EncasedCircle:
    //                break;
    //            case eFramePropType.BucklingRestrainedBrace:
    //                break;
    //            case eFramePropType.CoreBrace_BRB:
    //                break;
    //            case eFramePropType.ConcreteTee:
    //                break;
    //            case eFramePropType.ConcreteBox:
    //                break;
    //            case eFramePropType.ConcretePipe:
    //                break;
    //            case eFramePropType.ConcreteCross:
    //                break;
    //            case eFramePropType.SteelPlate:
    //                break;
    //            case eFramePropType.SteelRod:
    //                break;
    //            default:
    //                throw new NotImplementedException("Section convertion for the type: " + propertyType.ToString() + "is not implmented in ETABS adapter");
    //        }
    //        if (dimensions == null)
    //            throw new NotImplementedException("Section convertion for the type: " + propertyType.ToString() + "is not implmented in ETABS adapter");
    //        #endregion


    //        oM.Common.Materials.Material material = GetMaterial(modelData, materialName);

    //        switch (constructSelector)
    //        {
    //            case "fromDimensions":
    //                switch (material.Type)
    //                {
    //                    case oM.Common.Materials.MaterialType.Steel:
    //                        bhSectionProperty = Create.SteelSectionFromDimensions(dimensions);
    //                        break;
    //                    case oM.Common.Materials.MaterialType.Concrete:
    //                        bhSectionProperty = Create.ConcreteSectionFromDimensions(dimensions);
    //                        break;
    //                    case oM.Common.Materials.MaterialType.Aluminium:
    //                    case oM.Common.Materials.MaterialType.Timber:
    //                    case oM.Common.Materials.MaterialType.Rebar:
    //                    case oM.Common.Materials.MaterialType.Tendon:
    //                    case oM.Common.Materials.MaterialType.Glass:
    //                    case oM.Common.Materials.MaterialType.Cable:
    //                    default:
    //                        throw new NotImplementedException("no material type for selected section implemented");
    //                }
    //                break;
    //            case "explicit":
    //                ExplicitSection eSection = new ExplicitSection();
    //                eSection.Area = Area;
    //                eSection.Asy = As2;
    //                eSection.Asz = As3;
    //                //eSection.CentreY = ;
    //                //eSection.CentreZ = ;
    //                //eSection.Iw = 0;//warping
    //                eSection.Iy = I22;
    //                eSection.Iz = I33;
    //                eSection.J = Torsion;
    //                eSection.Rgy = R22;
    //                eSection.Rgz = R33;
    //                eSection.Sy = S22;//capacity - plastic (wply)
    //                eSection.Sz = S33;
    //                //eSection.Vpy = 0;
    //                //eSection.Vpz = 0;
    //                //eSection.Vy = 0;
    //                //eSection.Vz = 0;
    //                eSection.Zy = Z22;//capacity elastic
    //                eSection.Zz = Z33;
    //                break;
    //            default:
    //                break;
    //        }

    //        bhSectionProperty.Material = material;
    //        bhSectionProperty.Name = propertyName;
    //        bhSectionProperty.CustomData.Add(AdapterId, propertyName);
    //        modelData.sectionDict.Add(propertyName, bhSectionProperty);

    //        return bhSectionProperty;
    //    }

    //    public static void SetSectionProperty(ModelData modelData, ISectionProperty bhSection)
    //    {

    //        string materialName = "";

    //        if (modelData.sectionDict.ContainsKey(bhSection.Name))
    //        {
    //            // nothing ?
    //        }
    //        else
    //        {
    //            if (bhSection.Material == null)
    //            {
    //                //assign some default and/or throw error? TODO
    //            }
    //            else
    //            {
    //                SetMaterial(modelData, bhSection.Material);
    //            }

    //            SetSpecificSection(bhSection as dynamic, modelData.model);
    //            modelData.sectionDict.Add(bhSection.Name, bhSection);
    //        }

    //    }

    //    private static void SetSpecificSection(SteelSection section, cSapModel model)
    //    {
    //        SetSectionDimensions(section.SectionDimensions, section.Name, section.Material.Name, model);
    //    }

    //    private static void SetSpecificSection(ConcreteSection section, cSapModel model)
    //    {
    //        SetSectionDimensions(section.SectionDimensions, section.Name, section.Material.Name, model);
    //    }

    //    private static void SetSpecificSection(CableSection section, cSapModel model)
    //    {
    //        //no ISectionDimentions
    //        throw new NotImplementedException();
    //    }

    //    private static void SetSpecificSection(CompositeSection section, cSapModel model)
    //    {
    //        //contains SteelSection and ConcreteScetion
    //        throw new NotImplementedException();
    //    }

    //    private static void SetSpecificSection(ExplicitSection section, cSapModel model)
    //    {
    //        model.PropFrame.SetGeneral(section.Name, section.Material.Name, section.CentreZ * 2, section.CentreY * 2, section.Area, section.Asy, section.Asz, section.J, section.Iy, section.Iz, section.Sy, section.Sz, section.Zy, section.Sz, section.Rgy, section.Rgz);
    //    }

    //    #region section dimensions

    //    private static void SetSectionDimensions(ISectionProfile sectionDimensions, string sectionName, string materialName, cSapModel model)
    //    {
    //        SetSpecificDimensions(sectionDimensions as dynamic, sectionName, materialName, model);
    //    }

    //    private static void SetSpecificDimensions(BoxProfile dimensions, string sectionName, string materialName, cSapModel model)
    //    {
    //        model.PropFrame.SetTube(sectionName, materialName, dimensions.Height, dimensions.Width, dimensions.Thickness, dimensions.Thickness);
    //    }

    //    private static void SetSpecificDimensions(FabricatedBoxProfile dimensions, string sectionName, string materialName, cSapModel model)
    //    {
    //        if (dimensions.TopFlangeThickness != dimensions.BotFlangeThickness)
    //            throw new NotImplementedException("different thickness of top and bottom flange is not supported in ETABS");
    //        model.PropFrame.SetTube(sectionName, materialName, dimensions.Height, dimensions.Width, dimensions.TopFlangeThickness, dimensions.WebThickness);
    //    }

    //    private static void SetSpecificDimensions(ISectionProfile dimensions, string sectionName, string materialName, cSapModel model)
    //    {
    //        model.PropFrame.SetISection(sectionName, materialName, dimensions.Height, dimensions.Width, dimensions.FlangeThickness, dimensions.WebThickness, dimensions.Width, dimensions.FlangeThickness);
    //    }

    //    private static void SetSpecificDimensions(FabricatedISectionProfile dimensions, string sectionName, string materialName, cSapModel model)
    //    {
    //        model.PropFrame.SetISection(sectionName, materialName, dimensions.Height, dimensions.TopFlangeWidth, dimensions.TopFlangeThickness, dimensions.WebThickness, dimensions.BotFlangeWidth, dimensions.BotFlangeThickness);
    //    }

    //    private static void SetSpecificDimensions(ChannelProfile dimensions, string sectionName, string materialName, cSapModel model)
    //    {
    //        model.PropFrame.SetChannel(sectionName, materialName, dimensions.Height, dimensions.FlangeWidth, dimensions.FlangeThickness, dimensions.WebThickness);
    //    }

    //    private static void SetSpecificDimensions(AngleProfile dimensions, string sectionName, string materialName, cSapModel model)
    //    {
    //        model.PropFrame.SetAngle(sectionName, materialName, dimensions.Height, dimensions.Width, dimensions.FlangeThickness, dimensions.WebThickness);
    //    }

    //    private static void SetSpecificDimensions(TSectionProfile dimensions, string sectionName, string materialName, cSapModel model)
    //    {
    //        model.PropFrame.SetTee(sectionName, materialName, dimensions.Height, dimensions.Width, dimensions.FlangeThickness, dimensions.WebThickness);
    //    }

    //    private static void SetSpecificDimensions(ZSectionProfile dimensions, string sectionName, string materialName, cSapModel model)
    //    {
    //        throw new NotImplementedException("Zed-Section? Never heard of it!");
    //    }

    //    private static void SetSpecificDimensions(RectangleProfile dimensions, string sectionName, string materialName, cSapModel model)
    //    {
    //        model.PropFrame.SetRectangle(sectionName, materialName, dimensions.Height, dimensions.Width);
    //    }

    //    #endregion

    //}
}
