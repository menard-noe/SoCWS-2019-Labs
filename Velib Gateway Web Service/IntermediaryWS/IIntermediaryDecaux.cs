﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json.Linq;


namespace IntermediaryWS
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IIntermediaryDecaux
    {

        [OperationContract]
        String GetStationsInfoCity(int value);

        [OperationContract]
        List<Double> FindStation(String depart, String arrive);

        [OperationContract]
        List<String> GetAllCities();

        [OperationContract]
        List<Stations> GetStationCity(String city);

        [OperationContract]
        Stat GetStat();

        [OperationContract]
        void SetTimer(TimeSpan timer);
    }

    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    // Vous pouvez ajouter des fichiers XSD au projet. Une fois le projet généré, vous pouvez utiliser directement les types de données qui y sont définis, avec l'espace de noms "IntermediaryWS.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
