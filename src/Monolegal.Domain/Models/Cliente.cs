﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monolegal.Domain.Models
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string Ciudad { get; set; }

        public int NIT { get; set; }

        public long Celular { get; set; }

        public List<Factura> Facturas;

        public List<Mensaje> mensajes;
    }
}
