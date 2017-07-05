using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GT_MP_vehicleInfo.Data
{
    public class VehicleHorns
    {
	    
	    // Taken from scripthookvdotnet
        public static readonly ReadOnlyDictionary<int, Tuple<string, string>> HornNames = new ReadOnlyDictionary
			<int, Tuple<string, string>>(
			new Dictionary<int, Tuple<string, string>>
			{
				{-1,  new Tuple<string, string>("CMOD_HRN_0", "Stock Horn")},
				{0,  new Tuple<string, string>("CMOD_HRN_TRK","Truck Horn")},
				{1,  new Tuple<string, string>("CMOD_HRN_COP", "Cop Horn")},
				{2,  new Tuple<string, string>("CMOD_HRN_CLO", "Clown Horn")},
				{3,  new Tuple<string, string>("CMOD_HRN_MUS1", "Musical Horn 1")},
				{4,  new Tuple<string, string>("CMOD_HRN_MUS2", "Musical Horn 2")},
				{5,  new Tuple<string, string>("CMOD_HRN_MUS3", "Musical Horn 3")},
				{6,  new Tuple<string, string>("CMOD_HRN_MUS4", "Musical Horn 4")},
				{7,  new Tuple<string, string>("CMOD_HRN_MUS5", "Musical Horn 5")},
				{8,  new Tuple<string, string>("CMOD_HRN_SAD", "Sad Trombone")},
				{9,  new Tuple<string, string>("HORN_CLAS1", "Classical Horn 1")},
				{10,  new Tuple<string, string>("HORN_CLAS2", "Classical Horn 2")},
				{11,  new Tuple<string, string>("HORN_CLAS3", "Classical Horn 3")},
				{12,  new Tuple<string, string>("HORN_CLAS4", "Classical Horn 4")},
				{13,  new Tuple<string, string>("HORN_CLAS5", "Classical Horn 5")},
				{14,  new Tuple<string, string>("HORN_CLAS6", "Classical Horn 6")},
				{15,  new Tuple<string, string>("HORN_CLAS7", "Classical Horn 7")},
				{16,  new Tuple<string, string>("HORN_CNOTE_C0", "Scale Do")},
				{17,  new Tuple<string, string>("HORN_CNOTE_D0", "Scale Re")},
				{18,  new Tuple<string, string>("HORN_CNOTE_E0", "Scale Mi")},
				{19,  new Tuple<string, string>("HORN_CNOTE_F0", "Scale Fa")},
				{20,  new Tuple<string, string>("HORN_CNOTE_G0", "Scale Sol")},
				{21,  new Tuple<string, string>("HORN_CNOTE_A0", "Scale La")},
				{22,  new Tuple<string, string>("HORN_CNOTE_B0", "Scale Ti")},
				{23,  new Tuple<string, string>("HORN_CNOTE_C1", "Scale Do (High)")},
				{24,  new Tuple<string, string>("HORN_HIPS1", "Jazz Horn 1")},
				{25,  new Tuple<string, string>("HORN_HIPS2", "Jazz Horn 2")},
				{26,  new Tuple<string, string>("HORN_HIPS3", "Jazz Horn 3")},
				{27,  new Tuple<string, string>("HORN_HIPS4", "Jazz Horn Loop")},
				{28,  new Tuple<string, string>("HORN_INDI_1", "Star Spangled Banner 1")},
				{29,  new Tuple<string, string>("HORN_INDI_2", "Star Spangled Banner 2")},
				{30,  new Tuple<string, string>("HORN_INDI_3", "Star Spangled Banner 3")},
				{31,  new Tuple<string, string>("HORN_INDI_4", "Star Spangled Banner 4")},
				{32,  new Tuple<string, string>("HORN_LUXE2", "Classical Horn Loop 1")},
				{33,  new Tuple<string, string>("HORN_LUXE1", "Classical Horn 8")},
				{34,  new Tuple<string, string>("HORN_LUXE3", "Classical Horn Loop 2")},
				{35,  new Tuple<string, string>("HORN_LUXE2", "Classical Horn Loop 1")},
				{36,  new Tuple<string, string>("HORN_LUXE1", "Classical Horn 8")},
				{37,  new Tuple<string, string>("HORN_LUXE3", "Classical Horn Loop 2")},
				{38,  new Tuple<string, string>("HORN_HWEEN1", "Halloween Loop 1")},
				{39,  new Tuple<string, string>("HORN_HWEEN1", "Halloween Loop 1")},
				{40,  new Tuple<string, string>("HORN_HWEEN2", "Halloween Loop 2")},
				{41,  new Tuple<string, string>("HORN_HWEEN2", "Halloween Loop 2")},
				{42,  new Tuple<string, string>("HORN_LOWRDER1", "San Andreas Loop")},
				{43,  new Tuple<string, string>("HORN_LOWRDER1", "San Andreas Loop")},
				{44,  new Tuple<string, string>("HORN_LOWRDER2", "Liberty City Loop")},
				{45,  new Tuple<string, string>("HORN_LOWRDER2", "Liberty City Loop")},
				{46,  new Tuple<string, string>("HORN_XM15_1", "Festive Loop 1")},
				{47,  new Tuple<string, string>("HORN_XM15_2", "Festive Loop 2")},
				{48,  new Tuple<string, string>("HORN_XM15_3", "Festive Loop 3")}
			});
    }
}