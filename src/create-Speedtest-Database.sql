/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.speedtest
	(
	id bigint NOT NULL IDENTITY (1, 1),
	download bigint NOT NULL,
	upload bigint NOT NULL,
	ping int NOT NULL,
	serverid bigint NOT NULL,
	logTime datetime NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.speedtest ADD CONSTRAINT
	PK_speedtest PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.speedtest SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.speedtest', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.speedtest', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.speedtest', 'Object', 'CONTROL') as Contr_Per 
