delete from task
where documentid <54;

delete from keywordstructurecontentrelation
where StructureContentId in 
(select id from structurecontent 
where documentid <54)
and structurecontentid < 600;

delete from keyword
where id not in (select keywordid from keywordstructurecontentrelation)
and id < 600;

delete from structurecontent 
where documentid <54;

delete from document
where id <54;


delete from mtc.user where id < 9;