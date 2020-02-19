use Demo
go

/*
drop table ArticleTag
drop table Article
drop table Tag
go

create table Article ([id] integer not null identity(1,1) primary key, [name] nvarchar(256))
create table Tag ([id] integer not null identity(1,1) primary key, [name] nvarchar(256))
create table ArticleTag ([id] integer not null identity(1,1) primary key, [article_id] integer null foreign key([article_id]) references [Article] ([id]), [tag_id] integer null foreign key([tag_id]) references [Tag] ([id]))
go
*/

select Article.[name], '#' + Tag.[name]
from Article
	left join ArticleTag on Article.id = ArticleTag.article_id
	left join Tag on ArticleTag.tag_id = Tag.id

order by Article.[name], Tag.[name]