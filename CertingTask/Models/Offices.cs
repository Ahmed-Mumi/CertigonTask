using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CertingTask.Models
{
    [SerializableAttribute()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Offices
    {
        [XmlElement("Organization")]
        public Organization Organization { get; set; }
    }
}
