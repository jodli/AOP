
#region LicenseHeader
/*
 * Copyright (C) 2014 Jan-Olaf Becker
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */
#endregion

using System;
using System.Collections;
using System.Reflection;

namespace ParameterValidation
{
    public static class AOPConfig
    {
        private static Hashtable associations = new Hashtable();
        public static bool Enabled = true;

        public static void SetAssoc(Type classType, Type controllerType, IMessageMatcher matcher)
        {
            ConstructorInfo ci = controllerType.GetConstructor(Type.EmptyTypes);
            AOPBaseController controller = (AOPBaseController)ci.Invoke(null);
            associations[classType] = new AOPControllerInfo(controller, matcher);
        }

        public static AOPControllerInfo GetAssoc(Type classType)
        {
            return (AOPControllerInfo)associations[classType];
        }
    }
}