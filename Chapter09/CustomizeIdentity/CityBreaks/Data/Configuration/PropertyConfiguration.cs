
using CityBreaks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace CityBreaks.Data.Configuration
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasData(new List<Property>
        {
            new Property { Id = 1, CityId = 10, MaxNumberOfGuests = 1, DayRate = 81.00m, Name = "Hotel Paris", Address = "Rue de Reynard" },
            new Property { Id = 2, CityId = 4, MaxNumberOfGuests = 1, DayRate = 75.00m, Name = "Andersen Hotel", Address = "Vester Volgade" },
            new Property { Id = 3, CityId = 7, MaxNumberOfGuests = 2, DayRate = 72.00m, Name = "Ratz Hotel", Address = "The Strand" },
            new Property { Id = 4, CityId = 2, MaxNumberOfGuests = 2, DayRate = 42.00m, Name = "Gothic Hotel", Address = "Carrer Dels Talles" },
            new Property { Id = 5, CityId = 3, MaxNumberOfGuests = 3, DayRate = 68.00m, Name = "Beetle Hotel", Address = "Kurfürstenstraße" },
            new Property { Id = 6, CityId = 12, MaxNumberOfGuests = 3, DayRate = 50.00m, Name = "Merchant's Hotel", Address = "Calle dei Mercanti" },
            new Property { Id = 7, CityId = 8, MaxNumberOfGuests = 2, DayRate = 87.00m, Name = "Tapas Hotel", Address = "Calle del Amparo" },
            new Property { Id = 8, CityId = 6, MaxNumberOfGuests = 1, DayRate = 81.00m, Name = "Halfpenny Hotel", Address = "Cowgate" },
            new Property { Id = 9, CityId = 4, MaxNumberOfGuests = 3, DayRate = 60.00m, Name = "Mermaid Inn", Address = "Magstraede" },
            new Property { Id = 10, CityId = 1, MaxNumberOfGuests = 2, DayRate = 72.00m, Name = "Dam Hotel", Address = "Beursstraat" },
            new Property { Id = 11, CityId = 12, MaxNumberOfGuests = 3, DayRate = 70.00m, Name = "Gondalo Hotel", Address = "Calle Oche" },
            new Property { Id = 12, CityId = 9, MaxNumberOfGuests = 4, DayRate = 52.00m, Name = "New Yorker", Address = "7th Avenue" },
            new Property { Id = 13, CityId = 5, MaxNumberOfGuests = 2, DayRate = 66.00m, Name = "Hotel Kalisi", Address = "Hlidina ul." },
            new Property { Id = 14, CityId = 4, MaxNumberOfGuests = 1, DayRate = 66.00m, Name = "Schlaafhaus", Address = "Svætegarde" },
            new Property { Id = 15, CityId = 2, MaxNumberOfGuests = 1, DayRate = 68.00m, Name = "The Schafer", Address = "Carrer de Ferren" },
            new Property { Id = 16, CityId = 3, MaxNumberOfGuests = 1, DayRate = 58.00m, Name = "Beliner Hotel", Address = "Pohlstraße" },
            new Property { Id = 17, CityId = 5, MaxNumberOfGuests = 4, DayRate = 50.00m, Name = "7", Address = "Đorđićeva ul." },
            new Property { Id = 18, CityId = 8, MaxNumberOfGuests = 3, DayRate = 86.00m, Name = "Ceveceria Hotel", Address = "Calle de la Fe" },
            new Property { Id = 19, CityId = 7, MaxNumberOfGuests = 2, DayRate = 89.00m, Name = "The Sleepover", Address = "Charing Cross Road" },
            new Property { Id = 20, CityId = 1, MaxNumberOfGuests = 1, DayRate = 69.00m, Name = "14", Address = "Nieuwendijk" },
            new Property { Id = 21, CityId = 4, MaxNumberOfGuests = 3, DayRate = 41.00m, Name = "Nummer Ni", Address = "Sankt Annæ Pl" },
            new Property { Id = 22, CityId = 1, MaxNumberOfGuests = 1, DayRate = 86.00m, Name = "33", Address = "Wolvenstraate" },
            new Property { Id = 23, CityId = 6, MaxNumberOfGuests = 2, DayRate = 86.00m, Name = "The Drop Inn Well", Address = "Grassmarket" },
            new Property { Id = 24, CityId = 4, MaxNumberOfGuests = 3, DayRate = 50.00m, Name = "32", Address = "Christianshavn Voldgade" },
            new Property { Id = 25, CityId = 9, MaxNumberOfGuests = 2, DayRate = 52.00m, Name = "The Theatre Hotel", Address = "Broadway" },
            new Property { Id = 26, CityId = 6, MaxNumberOfGuests = 2, DayRate = 82.00m, Name = "Bide A Wee", Address = "Castle Hill" },
            new Property { Id = 27, CityId = 4, MaxNumberOfGuests = 1, DayRate = 59.00m, Name = "16", Address = "Nørre Allé" },
            new Property { Id = 28, CityId = 1, MaxNumberOfGuests = 3, DayRate = 69.00m, Name = "The Lion Hotel", Address = "Oudezijds Voorburgwal" },
            new Property { Id = 29, CityId = 6, MaxNumberOfGuests = 2, DayRate = 89.00m, Name = "15", Address = "Fraser Street" },
            new Property { Id = 30, CityId = 9, MaxNumberOfGuests = 1, DayRate = 63.00m, Name = "1742", Address = "W 30th St" },
            new Property { Id = 31, CityId = 4, MaxNumberOfGuests = 2, DayRate = 53.00m, Name = "6", Address = "Hans Kirks Wej" },
            new Property { Id = 32, CityId = 12, MaxNumberOfGuests = 4, DayRate = 69.00m, Name = "17", Address = "Calle Ponti di Venici" },
            new Property { Id = 33, CityId = 6, MaxNumberOfGuests = 1, DayRate = 43.00m, Name = "The Majestic", Address = "Princes Street" },
            new Property { Id = 34, CityId = 8, MaxNumberOfGuests = 4, DayRate = 71.00m, Name = "Hotel Mardi Gras", Address = "Calle del Bosce" },
            new Property { Id = 35, CityId = 6, MaxNumberOfGuests = 1, DayRate = 56.00m, Name = "Atlantic Hotel", Address = "George Street" },
            new Property { Id = 36, CityId = 1, MaxNumberOfGuests = 4, DayRate = 46.00m, Name = "Van Dijk Hotel", Address = "Damstraat" },
            new Property { Id = 37, CityId = 9, MaxNumberOfGuests = 1, DayRate = 89.00m, Name = "The Presidents Hotel", Address = "Madison Avenue" },
            new Property { Id = 38, CityId = 2, MaxNumberOfGuests = 3, DayRate = 88.00m, Name = "Hotel Colonial", Address = "Via Laietana" },
            new Property { Id = 39, CityId = 3, MaxNumberOfGuests = 2, DayRate = 87.00m, Name = "Saigon Night", Address = "Bülowstraße" },
            new Property { Id = 40, CityId = 6, MaxNumberOfGuests = 3, DayRate = 81.00m, Name = "The Royal", Address = "Queen Street" },
            new Property { Id = 41, CityId = 12, MaxNumberOfGuests = 3, DayRate = 58.00m, Name = "Hotel Soprano", Address = "Calle de Mezzo" },
            new Property { Id = 42, CityId = 6, MaxNumberOfGuests = 1, DayRate = 44.00m, Name = "The Cudogan", Address = "St Andrew Square" },
            new Property { Id = 43, CityId = 12, MaxNumberOfGuests = 3, DayRate = 60.00m, Name = "Hotel Antonio", Address = "Via Canale" },
            new Property { Id = 44, CityId = 11, MaxNumberOfGuests = 4, DayRate = 53.00m, Name = "Hotel Ponti", Address = "Via Barberini" },
            new Property { Id = 45, CityId = 10, MaxNumberOfGuests = 3, DayRate = 53.00m, Name = "Hotel Seine", Address = "Rue Visconti" },
            new Property { Id = 46, CityId = 9, MaxNumberOfGuests = 3, DayRate = 65.00m, Name = "452", Address = "6th Ave" },
            new Property { Id = 47, CityId = 4, MaxNumberOfGuests = 2, DayRate = 60.00m, Name = "City Hotel", Address = "Favergade" },
            new Property { Id = 48, CityId = 11, MaxNumberOfGuests = 1, DayRate = 89.00m, Name = "Bottino Hotel", Address = "Via della Corozza" },
            new Property { Id = 49, CityId = 6, MaxNumberOfGuests = 1, DayRate = 73.00m, Name = "124", Address = "South Bridge" },
            new Property { Id = 50, CityId = 4, MaxNumberOfGuests = 4, DayRate = 75.00m, Name = "Det Lille", Address = "Lavendelstræde" }
        });
        }
    }
}