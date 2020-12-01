//REQUETES SIMPLES

//Question 1. Combien y a-t-il d’utilisateurs dans la base de données ?
db.runCommand({ count: 'users' })

//Question 2. Combien y a-t-il de films dans la base de données ?
db.runCommand({ count: 'movies' })

//Question 3. Quelle est l’occupation de Clifford Johnathan ? 
//Ecrivez une requêtes dont la réponse affiche uniquement son nom et son occupation.
db.users.find(
    { name: "Clifford Johnathan" },
    { "name": 1, "occupation": 1, "_id": 0 }
).pretty()

//Question 4. Combien d’utilisateurs ont entre 18 et 30 ans (inclus) ?
db.users.find(
    { age: { $gte: 18, $lte: 30 } }
).count()

//Question 5. Combien d’utilisateurs sont artistes (artist) ou scientifiques (scientist) ? 
db.users.find(
    { $or: [{ occupation: "artist" }, { occupation: "scientist" }] }
).count()

//Question 6. Quelles sont les dix femmes auteurs (writer) les plus âgées ?
db.users.find(
    { gender: "F", occupation: "writer" },
    { "name": 1, "age": 1, "_id": 0 }
).sort({ age: -1 }).limit(10).pretty()

//Question 7. Quelles sont toutes les occupations présentes dans la base de données ? 
db.users.distinct("occupation")

//INSERTIONS, MAJ ET SUPPRESSIONS

//Question 8. Insérer un nouvel utilisateur dans la base de données (vous, par exemple). 
try {
    db.users.insertOne(
        {
            _id: 6041, name: "Théo Tarbé", gender: "M", age: 21, occupation: "student ECE",
            movies: [
                { movieid: 1419, rating: 3, timestamp: 956714815 },
                { movieid: 920, rating: 5, timestamp: 956706827 }
            ]
        });
} catch (e) {
    print(e);
}

//Question 9. Supprimer l’entrée de la base de données.
db.users.remove({ _id: 6041 })

//Question 10. Pour tous les utilisateurs qui ont pour occupation "programmer", changer cette occupation en "developer".
try {
    db.users.updateMany(
        { "occupation": "programmer" },
        { $set: { "occupation": "developer" } }
    );
} catch (e) {
    print(e);
}

//Question 11. Les genres du film "Cinderella" devraient être Animation, Children's et Musical.
//Modifier en une seule requête le document correspondant pour qu’il contienne ces trois genres sans doublon.
try {
    db.movies.updateMany(
        { "title": "Cinderella (1950)" },
        { $set: { "genres": "Children's|Musical|Animation" } }
    );
} catch (e) {
    print(e);
}

//EXPRESSIONS REGULIÈRES 

//Question 12. Combien de films sont sortis dans les années quatre-vingt ?
//(l’année de sortie est indiquée entre parenthèses à la fin du titre de chaque film)
db.movies.find(
    { title: { $regex: /198/ } }
).count()

//Question 13. Combien y a-t-il de films d’horreur ?
db.movies.find(
    { genres: /.*Horror.*/ }
).count()

//Question 14. Combien de films ont pour type à la fois "Musical" et "Romance” ?
db.movies.find(
    { $and: [{ genres: /.*Musical.*/ }, { genres: /.*Romance.*/ }] }
).count()

//REQUETES SUR DES TABLEAUX

//Question 15. Combien d’utilisateurs ont noté le film qui a pour id 1196 (Star Wars: Episode V - The Empire Strikes Back (1980)) ?
db.users.find(
    { "movies.movieid": 1196 }
).count()

//Question 16. Combien d’utilisateurs ont noté tous les films de la première trilogie Star Wars (id 260, 1196, 1210) ?
db.users.find(
    { $and: [{ "movies.movieid": 260 }, { "movies.movieid": 1196 }, { "movies.movieid": 1210 }] }
).count()

//Question 17. Combien d’utilisateurs ont notés exactement 48 films ?
db.users.find(
    { movies: { $size: 48 } }
).count()

//Question 18. Pour chaque utilisateur, créer un champ num_ratings qui indique le nombre de films qu’il a notés.
db.users.aggregate([
    { $addFields: { num_ratings: { $size: "$movies" } } },
    { $out: "users" }
])

//Question 19. Combien d’utilisateurs ont noté plus de 90 films ? 
db.users.find(
    { "num_ratings": { $gt: 90 } }
).count()

//Question 20. Quels sont les trois derniers films notés par Jayson Brad ?
db.users.aggregate([
    { $match: { name: "Jayson Brad" } },
    { $unwind: '$movies' },
    { $sort: { "movies.timestamp": -1 } },
    { $limit: 3 },
    {
        $lookup:
        {
            from: "movies",
            localField: "movies.movieid",
            foreignField: "_id",
            as: "movie_infos"
        }
    },
    {
        $group: {
            _id: "$_id",
            name: { "$first": "$name" },
            last_3_movies: { $push: { title: "$movie_infos.title" } }
        }
    }
]).pretty()

//AGREGATS

//Question 21. Montrer combien de films ont été produits durant chaque année des années 90 ; 
//ordonner les résultats de l’année la plus à la moins fructueuse.
db.movies.aggregate([
    { $match: { title: { $regex: /199/ } } },
    { $unwind: "$title" },
    {
        $project: {
            title_split: { $split: ["$title", " "] },
        }
    },
    { $addFields: { lastElem: { $last: "$title_split" } } },
    {
        $group: {
            _id: { year: "$lastElem" },
            nb_films: { $sum: 1 }
        }
    },
    { $sort: { nb_films: -1 } }
]).pretty()

//Question 22. Quelle est la note moyenne du film Pulp Fiction, qui a pour id 296 ?
db.users.aggregate(
    { $unwind: "$movies" },
    { $match: { "movies.movieid": 296 } },
    {
        $group: {
            _id: "$movies.movieid",
            ratingAvg: { $avg: "$movies.rating" },
        }
    }
).pretty()

//Question 23. En une seule requête, retourner pour chaque utilisateur son id, son nom, les notes maximale, minimale et moyenne qu’il a données, 
//et ordonner le résultat par note moyenne croissante.
db.users.aggregate(
    { $unwind: "$movies" },
    {
        $group: {
            _id: { id: "$_id", nom: "$name" },
            min_rating: { $min: "$movies.rating" },
            max_rating: { $max: "$movies.rating" },
            avg_rating: { $avg: "$movies.rating" }
        }
    },
    { $sort: { avg_rating: -1 } },
).pretty()

//Question 24. Quel est le genre le plus populaire en termes de nombre de notes ?
db.users.aggregate([
    { $unwind: "$movies" },
    {
        $lookup:
        {
            from: "movies",
            localField: "movies.movieid",
            foreignField: "_id",
            as: "movie_infos"
        }
    },
    { $unwind: "$movie_infos" },
    {
        $project:
        {
            _id: { movie: "$movie_infos._id" },
            Genres: { $split: ["$movie_infos.genres", "|"] },
        }
    },
    { $unwind: "$Genres" },
    {
        $group:
        {
            _id: "$Genres", 
            nb_rating: { $sum: 1 }
        }
    },
    { $sort: { nb_rating: -1 } },
    { $limit: 1 }
]).pretty()

//Question 25. Quel est le genre le mieux noté (celui dont la moyenne de toutes les notes est la plus élevée) ?
db.users.aggregate([
    { $unwind: "$movies" },
    {
        $lookup:
        {
            from: "movies",
            localField: "movies.movieid",
            foreignField: "_id",
            as: "movie_infos"
        }
    },
    { $unwind: "$movie_infos" },
    {
        $set:
        {
            _id: { movie: "$movie_infos._id" },
            Genres: { $split: ["$movie_infos.genres", "|"] }
        }
    },
    { $unwind: "$Genres" },
    {
        $group:
        {
            _id: "$Genres",
            avg_genre: { $avg: "$movies.rating" }
        }
    },
    { $sort: { avg_genre: -1 } },
    { $limit: 1 }
]).pretty()

