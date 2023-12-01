VNVC Dev - Preliminary Test
Hướng dẫn run app

I. Tạo Databasic bao gồm table và stored procedures.
 1.Table
   -- Users

	CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[BirthDate] [date] NULL,
 	CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
	(
	[PhoneNumber] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

  -- UserBet

	CREATE TABLE [dbo].[UserBet](
	[PhoneNumber] [varchar](20) NOT NULL,
	[DateBet] [datetime] NOT NULL,
	[HourSlot] [varchar](10) NOT NULL,
	[NumberBet] [varchar](5) NOT NULL,
	[Results] [nvarchar](40) NULL,
	[MoneyBet] [int] NULL,
 	CONSTRAINT [PK_UserBet] PRIMARY KEY CLUSTERED 
	(
	[PhoneNumber] ASC,
	[DateBet] ASC,
	[HourSlot] ASC,
	[NumberBet] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

 --  ResultSlots
	CREATE TABLE [dbo].[ResultSlots](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateResuls] [date] NOT NULL,
	[SlotResul] [varchar](3) NOT NULL,
	[Resuls] [varchar](2) NULL,
	 CONSTRAINT [PK_ResultSlots] PRIMARY KEY CLUSTERED 
	(
	[DateResuls] ASC,
	[SlotResul] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

 2. Stored procedures
  
  -- LoginUser
    CREATE PROC [dbo].[LoginUser] @PhoneNumber varchar(20)
	AS
	BEGIN
	DECLARE	@Result varchar(10)
	IF EXISTS (SELECT PhoneNumber FROM Users Where PhoneNumber=@PhoneNumber)
	 BEGIN
		SET @Result=1
	 END
	 ELSE
	 BEGIN
		SET @Result=0
	 END
	 SELECT @Result Result
	END
  -- InserUser
     CREATE PROC [dbo].[InserUser] @PhoneNumber varchar(20), @Name nvarchar(100), @BirthDate date
	AS 
	BEGIN
	DECLARE	@Result varchar(10)
	IF NOT EXISTS (SELECT PhoneNumber FROM Users Where PhoneNumber=@PhoneNumber)
	 BEGIN
		INSERT INTO Users(PhoneNumber,Name,BirthDate) values(@PhoneNumber,@Name,@BirthDate)
		SET @Result=1
	 END
	ELSE
	 BEGIN
		SET @Result=0
	 END
	 SELECT @Result  Result 
	END

  -- InserBet
     CREATE PROC [dbo].[InserBet] @PhoneNumber varchar(20), @HourSlot varchar(10), 
					 @NumberBet varchar(5), @MoneyBet int
	AS
	BEGIN
	DECLARE	@Result varchar(10)
	INSERT INTO UserBet(PhoneNumber,DateBet,HourSlot,NumberBet,Results,MoneyBet)
	VALUES (@PhoneNumber,GETDATE(),@HourSlot,@NumberBet,N'Đang chờ',@MoneyBet)
	IF EXISTS (SELECT * FROM UserBet WHERE PhoneNumber=@PhoneNumber and HourSlot=@HourSlot and NumberBet=@NumberBet)
		SET @Result=1
	ELSE
		SET @Result=0
	SELECT @Result Result 
	END

 -- GetUserInfo
	CREATE PROC [dbo].[GetUserInfo] @Phonenumber varchar(10)
	AS
	BEGIN
		SELECT Name, BirthDate FROM Users WHERE PhoneNumber=@Phonenumber
	END

 -- GetResulstBet
	CREATE PROC [dbo].[GetResulstBet] @Phonenumber varchar(10)
	AS
	BEGIN
	SELECT DateBet, HourSlot,NumberBet,MoneyBet,Results  FROM UserBet WHERE PhoneNumber=@PhoneNumber 
	ORDER BY DateBet DESC
	END
 -- CreateResultSlot 
	CREATE Proc CreateResultSlot @Date Date, @Slot varchar(2), @Res varchar(2)
	AS
	BEGIN
	 IF NOT EXISTS(SELECT * FROM  ResultSlots Where DateResuls=@Date and SlotResul=@Slot)
 	begin
	INSERT INTO ResultSlots(DateResuls,SlotResul,Resuls)
	VALUES(@Date,@Slot,@Res)
 	end
	END

 -- UserResultSlot 
 CREATE PROC UserResultSlot @Date Date, @Slot varchar(2)
	AS
	BEGIN
	Declare @ResSlot varchar(2)
	SET @ResSlot=(SELECT Resuls FROM ResultSlots WHERE DateResuls=@Date and SlotResul=@Slot)


	UPDATE UserBet   SET UserBet.Results =N'Thắng' 
	WHERE CONVERT(DATE, UserBet.DateBet)=@Date 
		and HourSlot=@Slot
		AND NumberBet=@ResSlot
	


	 UPDATE UserBet   SET UserBet.Results =N'Thua' 
	WHERE CONVERT(DATE, UserBet.DateBet)=@Date 
		and HourSlot=@Slot
		AND NumberBet != @ResSlot

	END

II. Đổi chuỗi kết nối database trong code c#.
	- Chuỗi kết nối data nằm trong class: ConnectSQL.cs

III. Buid app và setup Task Scheduler trên windowm để chạy file Server tự tạo slot và trả kết quả cho người chơi theo mỗi slot






