<h1 align="center">Media System</h1>

### Table of contents
- [Description](#description)
- [Application Design](#application-design)
- [Demo Instructions](#demo-instructions)

### Description

Minimal C# .Net Full-Stack Media Management Application that mimicks Spotify.

Application was developed using the following technologies and design principles:
- DotNet Entity Framework [Code-First development approach](https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application)
    - The development workflow in the code-first approach would be: 
        - Create or modify domain classes
        - configure these domain classes using [Fluent-API](https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties) or data annotation attributes
        - Create or update the database schema using automated migration or code-based migration.
- Initial test data was [seeded](https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding) to provide some context for the application that will be built on top of the database
- Classes with encapsulated fields or collections
- Input validation with appropritate error messages
- [Entity Type Heirarchy Mapping](https://learn.microsoft.com/en-us/ef/core/modeling/inheritance) through Inheritance
    - MediaCollection Base Class contains: 
        - Album Class
        - Podcast Class
    - Media Base Class contains:
        - Song Class
        - Episode Class

### Application Design

#### Database Design

Below are the application entities and their relationships:
- Song (Must belong to one album only. Can be composed by multiple artists)
- Album (Can contain many songs)
- Artist (Can compose many songs. Multiple artists can compose one song)
- Playlist (Can contain many songs)
- Podcast (Can contain many episodes)
- Each Podcast has a "Main Cast" of Artists. Artists are associated with an entire Podcast, not individual Episodes.
- Episodes have all of the same properties of a Song, but they must track their Air Date and only store "Guest Artists" 
- Listener Lists (Can contain many podcasts)

```Note: An Episode can never appear in a Playlist; A Song can never appear in a Podcast```


<img src="https://github.com/moorebarrett-jodiann/Media-System/blob/main/screenshots/Media-System-ERD.png" width="85%">
