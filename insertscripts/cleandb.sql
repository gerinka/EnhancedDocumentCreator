delete from task
where documentid <300;

delete from keywordstructurecontentrelation
where StructureContentId < 300;

delete from keyword
where id < 300;

delete from structurecontent 
where documentid <300;

delete from document
where id <300;
