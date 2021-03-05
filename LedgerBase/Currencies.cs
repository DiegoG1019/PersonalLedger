using DiegoG.LedgerBase.Attributes;
using DiegoG.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace DiegoG.LedgerBase
{
    public enum Currencies
    {
        [EnumMember(Value = "AED"), CurrencyData(UAEDirham, "AED", "د.إ*", 784, "UAE Dirham", "*s")]
        UAEDirham,

        [EnumMember(Value = "AFN"), CurrencyData(Afghani, "AFN", "Af*", 971, "Afghani", "*s")]
        Afghani,

        [EnumMember(Value = "ALL"), CurrencyData(Lek, "ALL", "L*", 008, "Lek", "*s")]
        Lek,

        [EnumMember(Value = "AMD"), CurrencyData(ArmenianDram, "AMD", "Դ*", 051, "Armenian Dram", "*s")]
        ArmenianDram,

        [EnumMember(Value = "AOA"), CurrencyData(Kwanza, "AOA", "*Kz", 973, "Kwanza", "*s")]
        Kwanza,

        [EnumMember(Value = "ARS"), CurrencyData(ArgentinePeso, "ARS", "$*", 032, "Argentine Peso", "*s")]
        ArgentinePeso,

        [EnumMember(Value = "AUD"), CurrencyData(AustralianDollar, "AUD", "$*", 036, "Australian Dollar", "*s")]
        AustralianDollar,

        /// <summary>
        /// Aka Aruban Guilder
        /// </summary>
        [EnumMember(Value = "AWG"), CurrencyData(Florin, "AWG", "*ƒ", 533, "Aruban Guilder/Florin", "*s")]
        Florin,

        [EnumMember(Value = "AZN"), CurrencyData(AzerbaijanianManat, "AZN", "*ман", 944, "Azerbaijanian Manat", "*s")]
        AzerbaijanianManat,

        [EnumMember(Value = "BAM"), CurrencyData(KonvertibilnaMarka, "BAM", "*КМ", 977, "Konvertibilna Marka", "*s")]
        KonvertibilnaMarka,

        [EnumMember(Value = "BBD"), CurrencyData(BarbadosDollar, "BBD", "*$", 052, "Barbados Dollar", "*s")]
        BarbadosDollar,

        [EnumMember(Value = "BDT"), CurrencyData(Taka, "BDT", "*৳", 050, "Taka", "*s")]
        Taka,

        [EnumMember(Value = "BGN"), CurrencyData(BulgarianLev, "BGN", "*лв", 975, "Bulgarian Lev", "*es")]
        BulgarianLev,

        [EnumMember(Value = "BHD"), CurrencyData(BahrainiDinar, "BHD", "ب.د*", 048, "Bahraini Dinar", "*s")]
        BahrainiDinar,

        [EnumMember(Value = "BIF"), CurrencyData(BurundiFranc, "BIF", "*₣", 108, "Burundi Franc", "*s")]
        BurundiFranc,

        [EnumMember(Value = "BMD"), CurrencyData(BermudianDollar, "BMD", "$*", 060, "Bermudian Dollar", "*s")]
        BermudianDollar,

        [EnumMember(Value = "BND"), CurrencyData(BruneiDollar, "BND", "$*", 096, "Brunei Dollar", "*s")]
        BruneiDollar,

        [EnumMember(Value = "BOB"), CurrencyData(Boliviano, "BOB", "*Bs.", 068, "Boliviano", "*s")]
        Boliviano,

        [EnumMember(Value = "BRL"), CurrencyData(BrazilianReal, "BRL", "R$*", 986, "Brazilian Real", "*s")]
        BrazilianReal,

        [EnumMember(Value = "BSD"), CurrencyData(BahamianDollar, "BSD", "$*", 044, "Bahamian Dollar", "*s")]
        BahamianDollar,

        [EnumMember(Value = "BTN"), CurrencyData(Ngultrum, "BTN", "", 064, "Ngultrum", "*s")]
        Ngultrum,

        [EnumMember(Value = "BWP"), CurrencyData(Pula, "BWP", "*P", 072, "Pula", "*s")]
        Pula,

        [EnumMember(Value = "BYN"), CurrencyData(BelarusianRuble, "BYN", "*Br", 933, "Belarusian Ruble", "*s")]
        BelarusianRuble,

        [EnumMember(Value = "BZD"), CurrencyData(BelizeDollar, "BZD", "$*", 084, "Belize Dollar", "*s")]
        BelizeDollar,

        [EnumMember(Value = "CAD"), CurrencyData(CanadianDollar, "CAD", "$*", 124, "Canadian Dollar", "*s")]
        CanadianDollar,

        [EnumMember(Value = "CDF"), CurrencyData(CongoleseFranc, "CDF", "*₣", 976, "Congolese Franc", "*s")]
        CongoleseFranc,

        [EnumMember(Value = "CHF"), CurrencyData(SwissFranc, "CHF", "*₣", 756, "Swiss Franc", "*s")]
        SwissFranc,

        [EnumMember(Value = "CLP"), CurrencyData(ChileanPeso, "CLP", "$*", 152, "Chilean Peso", "*s")]
        ChileanPeso,

        [EnumMember(Value = "CNY"), CurrencyData(Yuan, "CNY", "*¥", 156, "Yuan", "*s")]
        Yuan,

        [EnumMember(Value = "COP"), CurrencyData(ColombianPeso, "COP", "$*", 170, "Colombian Peso", "*s")]
        ColombianPeso,

        [EnumMember(Value = "CRC"), CurrencyData(CostaRicanColon, "CRC", "*₡", 188, "Costa Rican Colon", "*s")]
        CostaRicanColon,

        [EnumMember(Value = "CUP"), CurrencyData(CubanPeso, "CUP", "$*", 192, "Cuban Peso", "*s")]
        CubanPeso,

        [EnumMember(Value = "CVE"), CurrencyData(CapeVerdeEscudo, "CVE", "$*", 132, "Cape Verde Escudo", "*s")]
        CapeVerdeEscudo,

        [EnumMember(Value = "CZK"), CurrencyData(CzechKoruna, "CZK", "*Kč", 203, "Czech Koruna", "*s")]
        CzechKoruna,

        [EnumMember(Value = "DJF"), CurrencyData(DjiboutiFranc, "DJF", "*₣", 262, "Djibouti Franc", "*s")]
        DjiboutiFranc,

        [EnumMember(Value = "DKK"), CurrencyData(DanishKrone, "DKK", "*kr", 208, "Danish Krone", "*s")]
        DanishKrone,

        [EnumMember(Value = "DOP"), CurrencyData(DominicanPeso, "DOP", "$*", 214, "Dominican Peso", "*s")]
        DominicanPeso,

        [EnumMember(Value = "DZD"), CurrencyData(AlgerianDinar, "DZD", "د.ج*", 012, "Algerian Dinar", "*s")]
        AlgerianDinar,

        [EnumMember(Value = "EGP"), CurrencyData(EgyptianPound, "EGP", "£*", 818, "Egyptian Pound", "*s")]
        EgyptianPound,

        [EnumMember(Value = "ERN"), CurrencyData(Nakfa, "ERN", "*Nfk", 232, "Nakfa", "*s")]
        Nakfa,

        [EnumMember(Value = "ETB"), CurrencyData(EthiopianBirr, "ETB", "", 230, "Ethiopian Birr", "*s")]
        EthiopianBirr,

        [EnumMember(Value = "EUR"), CurrencyData(Euro, "EUR", "€*", 978, "Euro", "*s")]
        Euro,

        [EnumMember(Value = "FJD"), CurrencyData(FijiDollar, "FJD", "$*", 242, "Fiji Dollar", "*s")]
        FijiDollar,

        [EnumMember(Value = "FKP"), CurrencyData(FalklandIslandsPound, "FKP", "£*", 238, "Falkland Islands Pound", "*s")]
        FalklandIslandsPound,

        [EnumMember(Value = "GBP"), CurrencyData(PoundSterling, "GBP", "£*", 826, "Pound Sterling", "*s")]
        PoundSterling,

        [EnumMember(Value = "GEL"), CurrencyData(Lari, "GEL", "*ლ", 981, "Lari", "*s")]
        Lari,

        [EnumMember(Value = "GHS"), CurrencyData(Cedi, "GHS", "*₵", 936, "Cedi", "*s")]
        Cedi,

        [EnumMember(Value = "GIP"), CurrencyData(GibraltarPound, "GIP", "£*", 292, "Gibraltar Pound", "*s")]
        GibraltarPound,

        [EnumMember(Value = "GMD"), CurrencyData(Dalasi, "GMD", "*D", 270, "Dalasi", "*s")]
        Dalasi,

        [EnumMember(Value = "GNF"), CurrencyData(GuineaFranc, "GNF", "*₣", 324, "Guinea Franc", "*s")]
        GuineaFranc,

        [EnumMember(Value = "GTQ"), CurrencyData(Quetzal, "GTQ", "*Q", 320, "Quetzal", "*s")]
        Quetzal,

        [EnumMember(Value = "GYD"), CurrencyData(GuyanaDollar, "GYD", "$*", 328, "Guyana Dollar", "*s")]
        GuyanaDollar,

        [EnumMember(Value = "HKD"), CurrencyData(HongKongDollar, "HKD", "$*", 344, "Hong Kong Dollar", "*s")]
        HongKongDollar,

        [EnumMember(Value = "HNL"), CurrencyData(Lempira, "HNL", "*L", 340, "Lempira", "*s")]
        Lempira,

        [EnumMember(Value = "HRK"), CurrencyData(CroatianKuna, "HRK", "*Kn", 191, "Croatian Kuna", "*s")]
        CroatianKuna,

        [EnumMember(Value = "HTG"), CurrencyData(Gourde, "HTG", "*G", 332, "Gourde", "*s")]
        Gourde,

        [EnumMember(Value = "HUF"), CurrencyData(Forint, "HUF", "*Ft", 348, "Forint", "*s")]
        Forint,

        [EnumMember(Value = "IDR"), CurrencyData(Rupiah, "IDR", "*Rp", 360, "Rupiah", "*s")]
        Rupiah,

        [EnumMember(Value = "ILS"), CurrencyData(NewIsraeliShekel, "ILS", "*₪", 376, "New Israeli Shekel", "*s")]
        NewIsraeliShekel,

        [EnumMember(Value = "INR"), CurrencyData(IndianRupee, "INR", "*₹", 356, "Indian Rupee", "*s")]
        IndianRupee,

        [EnumMember(Value = "IQD"), CurrencyData(IraqiDinar, "IQD", "ع.د*", 368, "Iraqi Dinar", "*s")]
        IraqiDinar,

        [EnumMember(Value = "IRR"), CurrencyData(IranianRial, "IRR", "*﷼", 364, "Iranian Rial", "*s")]
        IranianRial,

        [EnumMember(Value = "ISK"), CurrencyData(IcelandKrona, "ISK", "*Kr", 352, "Iceland Krona", "*s")]
        IcelandKrona,

        [EnumMember(Value = "JMD"), CurrencyData(JamaicanDollar, "JMD", "$*", 388, "Jamaican Dollar", "*s")]
        JamaicanDollar,

        [EnumMember(Value = "JOD"), CurrencyData(JordanianDinar, "JOD", "*د.ا", 400, "Jordanian Dinar", "*s")]
        JordanianDinar,

        [EnumMember(Value = "JPY"), CurrencyData(Yen, "JPY", "*¥", 392, "Yen", "*s")]
        Yen,

        [EnumMember(Value = "KES"), CurrencyData(KenyanShilling, "KES", "*Sh", 404, "Kenyan Shilling", "*s")]
        KenyanShilling,

        [EnumMember(Value = "KGS"), CurrencyData(Som, "KGS", "", 417, "Som", "*s")]
        Som,

        [EnumMember(Value = "KHR"), CurrencyData(Riel, "KHR", "*៛", 116, "Riel", "*s")]
        Riel,

        [EnumMember(Value = "KPW"), CurrencyData(NorthKoreanWon, "KPW", "*₩", 408, "North Korean Won", "*s")]
        NorthKoreanWon,

        [EnumMember(Value = "KRW"), CurrencyData(SouthKoreanWon, "KRW", "*₩", 410, "South Korean Won", "*s")]
        SouthKoreanWon,

        [EnumMember(Value = "KWD"), CurrencyData(KuwaitiDinar, "KWD", "د.ك*", 414, "Kuwaiti Dinar", "*s")]
        KuwaitiDinar,

        [EnumMember(Value = "KYD"), CurrencyData(CaymanIslandsDollar, "KYD", "$*", 136, "Cayman Islands Dollar", "*s")]
        CaymanIslandsDollar,

        [EnumMember(Value = "KZT"), CurrencyData(Tenge, "KZT", "*〒", 398, "Tenge", "*s")]
        Tenge,

        [EnumMember(Value = "LAK"), CurrencyData(Kip, "LAK", "₭*", 418, "Kip", "*s")]
        Kip,

        [EnumMember(Value = "LBP"), CurrencyData(LebanesePound, "LBP", "*ل.ل", 422, "Lebanese Pound", "*s")]
        LebanesePound,

        [EnumMember(Value = "LKR"), CurrencyData(SriLankaRupee, "LKR", "*Rs", 144, "Sri Lanka Rupee", "*s")]
        SriLankaRupee,

        [EnumMember(Value = "LRD"), CurrencyData(LiberianDollar, "LRD", "$*", 430, "Liberian Dollar", "*s")]
        LiberianDollar,

        [EnumMember(Value = "LSL"), CurrencyData(Loti, "LSL", "*L", 426, "Loti", "*s")]
        Loti,

        [EnumMember(Value = "LYD"), CurrencyData(LibyanDinar, "LYD", "*ل.د", 434, "Libyan Dinar", "*s")]
        LibyanDinar,

        [EnumMember(Value = "MAD"), CurrencyData(MoroccanDirham, "MAD", "د.م*.", 504, "Moroccan Dirham", "*s")]
        MoroccanDirham,

        [EnumMember(Value = "MDL"), CurrencyData(MoldovanLeu, "MDL", "*L", 498, "Moldovan Leu", "*s")]
        MoldovanLeu,

        [EnumMember(Value = "MGA"), CurrencyData(MalagasyAriary, "MGA", "", 969, "Malagasy Ariary", "*s")]
        MalagasyAriary,

        [EnumMember(Value = "MKD"), CurrencyData(Denar, "MKD", "*ден", 807, "Denar", "*s")]
        Denar,

        [EnumMember(Value = "MMK"), CurrencyData(Kyat, "MMK", "*K", 104, "Kyat", "*s")]
        Kyat,

        [EnumMember(Value = "MNT"), CurrencyData(Tugrik, "MNT", "*₮", 496, "Tugrik", "*s")]
        Tugrik,

        [EnumMember(Value = "MOP"), CurrencyData(Pataca, "MOP", "*P", 446, "Pataca", "*s")]
        Pataca,

        [EnumMember(Value = "MRU"), CurrencyData(Ouguiya, "MRU", "*UM", 929, "Ouguiya", "*s")]
        Ouguiya,

        [EnumMember(Value = "MUR"), CurrencyData(MauritiusRupee, "MUR", "*₨", 480, "Mauritius Rupee", "*s")]
        MauritiusRupee,

        [EnumMember(Value = "MVR"), CurrencyData(Rufiyaa, "MVR", "ރ*.", 462, "Rufiyaa", "*s")]
        Rufiyaa,

        [EnumMember(Value = "MWK"), CurrencyData(Kwacha, "MWK", "*MK", 454, "Kwacha", "*s")]
        Kwacha,

        [EnumMember(Value = "MXN"), CurrencyData(MexicanPeso, "MXN", "$*", 484, "Mexican Peso", "*s")]
        MexicanPeso,

        [EnumMember(Value = "MYR"), CurrencyData(MalaysianRinggit, "MYR", "*RM", 458, "Malaysian Ringgit", "*s")]
        MalaysianRinggit,

        [EnumMember(Value = "MZN"), CurrencyData(Metical, "MZN", "*MTn", 943, "Metical", "*s")]
        Metical,

        [EnumMember(Value = "NAD"), CurrencyData(NamibiaDollar, "NAD", "$*", 516, "Namibia Dollar", "*s")]
        NamibiaDollar,

        [EnumMember(Value = "NGN"), CurrencyData(Naira, "NGN", "₦*", 566, "Naira", "*s")]
        Naira,

        [EnumMember(Value = "NIO"), CurrencyData(CordobaOro, "NIO", "*C$", 558, "Cordoba Oro", "*s")]
        CordobaOro,

        [EnumMember(Value = "NOK"), CurrencyData(NorwegianKrone, "NOK", "*kr", 578, "Norwegian Krone", "*s")]
        NorwegianKrone,

        [EnumMember(Value = "NPR"), CurrencyData(NepaleseRupee, "NPR", "₨*", 524, "Nepalese Rupee", "*s")]
        NepaleseRupee,

        [EnumMember(Value = "NZD"), CurrencyData(NewZealandDollar, "NZD", "$*", 554, "New Zealand Dollar", "*s")]
        NewZealandDollar,

        [EnumMember(Value = "OMR"), CurrencyData(RialOmani, "OMR", "*ر.ع.", 512, "Rial Omani", "*s")]
        RialOmani,

        [EnumMember(Value = "PAB"), CurrencyData(Balboa, "PAB", "*B/.", 590, "Balboa", "*s")]
        Balboa,

        [EnumMember(Value = "PEN"), CurrencyData(NuevoSol, "PEN", "*S/.", 604, "Nuevo Sol", "*s")]
        NuevoSol,

        [EnumMember(Value = "PGK"), CurrencyData(Kina, "PGK", "*K", 598, "Kina", "*s")]
        Kina,

        [EnumMember(Value = "PHP"), CurrencyData(PhilippinePeso, "PHP", "*₱", 608, "Philippine Peso", "*s")]
        PhilippinePeso,

        [EnumMember(Value = "PKR"), CurrencyData(PakistanRupee, "PKR", "₨*", 586, "Pakistan Rupee", "*s")]
        PakistanRupee,

        [EnumMember(Value = "PLN"), CurrencyData(PZloty, "PLN", "*zł", 985, "PZloty", "*s")]
        PZloty,

        [EnumMember(Value = "PYG"), CurrencyData(Guarani, "PYG", "*₲", 600, "Guarani", "*s")]
        Guarani,

        [EnumMember(Value = "QAR"), CurrencyData(QatariRial, "QAR", "ر.ق*", 634, "Qatari Rial", "*s")]
        QatariRial,

        [EnumMember(Value = "RON"), CurrencyData(Leu, "RON", "*L", 946, "Leu", "*s")]
        Leu,

        [EnumMember(Value = "RSD"), CurrencyData(SerbianDinar, "RSD", "*din", 941, "Serbian Dinar", "*s")]
        SerbianDinar,

        [EnumMember(Value = "RUB"), CurrencyData(RussianRuble, "RUB", "*р. ", 643, "Russian Ruble", "*s")]
        RussianRuble,

        [EnumMember(Value = "RWF"), CurrencyData(RwandaFranc, "RWF", "*₣", 646, "Rwanda Franc", "*s")]
        RwandaFranc,

        [EnumMember(Value = "SAR"), CurrencyData(SaudiRiyal, "SAR", "*ر.س", 682, "Saudi Riyal", "*s")]
        SaudiRiyal,

        [EnumMember(Value = "SBD"), CurrencyData(SolomonIslandsDollar, "SBD", "$*", 090, "Solomon Islands Dollar", "*s")]
        SolomonIslandsDollar,

        [EnumMember(Value = "SCR"), CurrencyData(SeychellesRupee, "SCR", "₨*", 690, "Seychelles Rupee", "*s")]
        SeychellesRupee,

        [EnumMember(Value = "SDG"), CurrencyData(SudanesePound, "SDG", "£*", 938, "Sudanese Pound", "*s")]
        SudanesePound,

        [EnumMember(Value = "SEK"), CurrencyData(SwedishKrona, "SEK", "*kr", 752, "Swedish Krona", "*s")]
        SwedishKrona,

        [EnumMember(Value = "SGD"), CurrencyData(SingaporeDollar, "SGD", "$*", 702, "Singapore Dollar", "*s")]
        SingaporeDollar,

        [EnumMember(Value = "SHP"), CurrencyData(SaintHelenaPound, "SHP", "£*", 654, "Saint Helena Pound", "*s")]
        SaintHelenaPound,

        [EnumMember(Value = "SLL"), CurrencyData(Leone, "SLL", "*Le", 694, "Leone", "*s")]
        Leone,

        [EnumMember(Value = "SOS"), CurrencyData(SomaliShilling, "SOS", "*Sh", 706, "Somali Shilling", "*s")]
        SomaliShilling,

        [EnumMember(Value = "SRD"), CurrencyData(SurinameDollar, "SRD", "$*", 968, "Suriname Dollar", "*s")]
        SurinameDollar,

        [EnumMember(Value = "STN"), CurrencyData(Dobra, "STN", "*Db", 930, "Dobra", "*s")]
        Dobra,

        [EnumMember(Value = "SYP"), CurrencyData(SyrianPound, "SYP", "ل.س*", 760, "Syrian Pound", "*s")]
        SyrianPound,

        [EnumMember(Value = "SZL"), CurrencyData(Lilangeni, "SZL", "*L", 748, "Lilangeni", "*s")]
        Lilangeni,

        [EnumMember(Value = "THB"), CurrencyData(Baht, "THB", "*฿", 764, "Baht", "*s")]
        Baht,

        [EnumMember(Value = "TJS"), CurrencyData(Somoni, "TJS", "*ЅМ", 972, "Somoni", "*s")]
        Somoni,

        [EnumMember(Value = "TMT"), CurrencyData(Manat, "TMT", "*m", 934, "Manat", "*s")]
        Manat,

        [EnumMember(Value = "TND"), CurrencyData(TunisianDinar, "TND", "*د.ت", 788, "Tunisian Dinar", "*s")]
        TunisianDinar,

        [EnumMember(Value = "TOP"), CurrencyData(Paanga, "TOP", "T$*", 776, "Pa’anga", "*s")]
        Paanga,

        [EnumMember(Value = "TRY"), CurrencyData(TurkishLira, "TRY", "₤*", 949, "Turkish Lira", "*s")]
        TurkishLira,

        [EnumMember(Value = "TTD"), CurrencyData(TrinidadandTobagoDollar, "TTD", "$*", 780, "Trinidad and Tobago Dollar", "*s")]
        TrinidadandTobagoDollar,

        [EnumMember(Value = "TWD"), CurrencyData(TaiwanDollar, "TWD", "$*", 901, "Taiwan Dollar", "*s")]
        TaiwanDollar,

        [EnumMember(Value = "TZS"), CurrencyData(TanzanianShilling, "TZS", "*Sh", 834, "Tanzanian Shilling", "*s")]
        TanzanianShilling,

        [EnumMember(Value = "UAH"), CurrencyData(Hryvnia, "UAH", "₴*", 980, "Hryvnia", "*s")]
        Hryvnia,

        [EnumMember(Value = "UGX"), CurrencyData(UgandaShilling, "UGX", "*Sh", 800, "Uganda Shilling", "*s")]
        UgandaShilling,

        [EnumMember(Value = "USD"), CurrencyData(USDollar, "USD", "$*", 840, "US Dollar", "*s")]
        USDollar,

        [EnumMember(Value = "UYU"), CurrencyData(PesoUruguayo, "UYU", "$*", 858, "Peso Uruguayo", "*s")]
        PesoUruguayo,

        [EnumMember(Value = "UZS"), CurrencyData(UzbekistanSum, "UZS", "", 860, "Uzbekistan Sum", "*s")]
        UzbekistanSum,

        [EnumMember(Value = "VES"), CurrencyData(BolivarSoberano, "VES", "*Bs S", 937, "Bolivar Soberano", "Bolivares Soberanos")]
        BolivarSoberano,

        [EnumMember(Value = "VND"), CurrencyData(Dong, "VND", "₫*", 704, "Dong", "*s")]
        Dong,

        [EnumMember(Value = "VUV"), CurrencyData(Vatu, "VUV", "*Vt", 548, "Vatu", "*s")]
        Vatu,

        [EnumMember(Value = "WST"), CurrencyData(Tala, "WST", "*T", 882, "Tala", "*s")]
        Tala,

        [EnumMember(Value = "XAF"), CurrencyData(CFAFrancBCEAO, "XAF", "*₣", 950, "CFA Franc BCEAO", "*s")]
        CFAFrancBCEAO,

        [EnumMember(Value = "XCD"), CurrencyData(EastCaribbeanDollar, "XCD", "$*", 951, "East Caribbean Dollar", "*s")]
        EastCaribbeanDollar,

        [EnumMember(Value = "XPF"), CurrencyData(CFPFranc, "XPF", "*₣", 953, "CFP Franc", "*s")]
        CFPFranc,

        [EnumMember(Value = "YER"), CurrencyData(YemeniRial, "YER", "﷼*", 886, "Yemeni Rial", "*s")]
        YemeniRial,

        [EnumMember(Value = "ZAR"), CurrencyData(Rand, "ZAR", "*R", 710, "Rand", "*s")]
        Rand,

        [EnumMember(Value = "ZMW"), CurrencyData(ZambianKwacha, "ZMW", "*ZK", 967, "Zambian Kwacha", "*s")]
        ZambianKwacha,

        [EnumMember(Value = "ZWL"), CurrencyData(ZimbabweDollar, "ZWL", "$*", 932, "Zimbabwe Dollar", "*s")]
        ZimbabweDollar
    }
}
