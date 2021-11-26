using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CertingTask.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Organization
    {
        [XmlAttribute()]
        public string RegistrationNumber { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Country")]
        public string Country { get; set; }
        [XmlElement("Address")]
        public string Address { get; set; }
        [XmlElement("Offices")]
        public List<Offices> Offices { get; set; }
    }
}
