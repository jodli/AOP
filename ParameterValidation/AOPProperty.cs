
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

using System.Diagnostics;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace ParameterValidation
{
    public class AOPProperty : IContextProperty, IContributeServerContextSink
    {
        public AOPProperty()
        { }

        public IMessageSink GetServerContextSink(IMessageSink nextSink)
        {
            IMessageSink logSink = new AOPSink(nextSink);
            return logSink;
        }

        public string Name { get { return "AOP"; } }

        public bool IsNewContextOK(Context c)
        {
            AOPProperty newContextLogProperty = c.GetProperty("AOP") as AOPProperty;
            if (newContextLogProperty == null)
            {
                Debug.Assert(false);
                return false;
            }
            return true;
        }

        public void Freeze(Context c)
        { }
    }
}
