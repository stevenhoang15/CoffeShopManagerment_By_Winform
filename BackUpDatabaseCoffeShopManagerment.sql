USE [QuanLyQuanCafe]
GO
/****** Object:  UserDefinedFunction [dbo].[fuConvertToUnsign1]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) 
RETURNS NVARCHAR(4000) 
AS 
BEGIN 
	IF @strInput IS NULL 
		RETURN @strInput 
	IF @strInput = '' 
		RETURN @strInput 
	DECLARE @RT NVARCHAR(4000) 
	DECLARE @SIGN_CHARS NCHAR(136) 
	DECLARE @UNSIGN_CHARS NCHAR (136) 
	SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 
	DECLARE @COUNTER int 
	DECLARE @COUNTER1 int 
	SET @COUNTER = 1 
	WHILE (@COUNTER <=LEN(@strInput)) 
		BEGIN 
			SET @COUNTER1 = 1 
			WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) 
				BEGIN 
					IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) 
						BEGIN 
							IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
							ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK 
						END SET @COUNTER1 = @COUNTER1 +1 
				END SET @COUNTER = @COUNTER +1 
		END SET @strInput = replace(@strInput,' ','-') 
			RETURN @strInput 
END
GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](100) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[PassWord] [nvarchar](1000) NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [date] NOT NULL,
	[DateCheckOut] [date] NULL,
	[idTable] [int] NOT NULL,
	[status] [int] NOT NULL,
	[discount] [int] NULL,
	[totalPrice] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NOT NULL,
	[idFood] [int] NOT NULL,
	[count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[idCategory] [int] NOT NULL,
	[price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodCategory]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableFood]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableFood](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[status] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (N'Kter') FOR [DisplayName]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [PassWord]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [DateCheckIn]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[BillInfo] ADD  DEFAULT ((0)) FOR [count]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT (N'Chưa đặt tên') FOR [name]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[FoodCategory] ADD  DEFAULT (N'Chưa đặt tên') FOR [name]
GO
ALTER TABLE [dbo].[TableFood] ADD  DEFAULT (N'Bàn chưa có tên') FOR [name]
GO
ALTER TABLE [dbo].[TableFood] ADD  DEFAULT (N'Trống') FOR [status]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([idTable])
REFERENCES [dbo].[TableFood] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idBill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idFood])
REFERENCES [dbo].[Food] ([id])
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[FoodCategory] ([id])
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteCategory]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_DeleteCategory]
@idCategory int
as begin
	select id into IdFoodDelete from Food where idCategory = @idCategory
	delete BillInfo where idFood in (select * from IdFoodDelete)
	delete Food where idCategory = @idCategory
	DROP TABLE IdFoodDelete

	delete FoodCategory where id = @idCategory
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDateAndPage]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_GetListBillByDateAndPage]
@checkIn date, @checkOut date, @page int
AS 
BEGIN
	DECLARE @pageRows INT = 10
	DECLARE @selectRows INT = @pageRows
	DECLARE @exceptRows INT = (@page - 1) * @pageRows
	
	;WITH BillShow AS( SELECT b.ID, t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá]
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable)
	
	SELECT TOP (@selectRows) * FROM BillShow WHERE id NOT IN (SELECT TOP (@exceptRows) id FROM BillShow)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetNumBillByDate]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetNumBillByDate]
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT COUNT(*)
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetStaffPart]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_GetStaffPart]
@useName nvarchar(100), @disName nvarchar(100)
as
begin
	select * from Account a
	where a.UserName like @useName and a.DisplayName like @disName
end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTableList]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_GetTableList]
as
begin
	select * from TableFood
end
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertBill]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_InsertBill]
@idTable int
as
begin
	INSERT INTO [dbo].[Bill]
           ([DateCheckIn]
           ,[DateCheckOut]
           ,[idTable]
           ,[status]
		   ,[discount])
     VALUES
           (GETDATE()
           ,null
           ,@idTable
           ,0
		   ,0)
end
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertBillInfo]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_InsertBillInfo]
@idBill int, @idFood int, @count int
as
begin
	declare @countBillInfo int;
	declare @foodCount int = 1;
	
	select @countBillInfo = bi.id, @foodCount = bi.count from BillInfo bi where bi.idBill = @idBill and @idFood = bi.idFood

	if(@countBillInfo > 0)
		begin
			declare @newCount int = @foodCount + @count;
			if(@newCount > 0)
				begin
					update BillInfo set count = @foodCount + @count where idBill = @idBill and idFood = @idFood
				end
			else
				delete BillInfo where idBill = @idBill and idFood = @idFood
		end	
	else
		begin
			if(@count > 0)
				begin
					INSERT INTO [dbo].[BillInfo]
					   ([idBill]
					   ,[idFood]
					   ,[count])
					VALUES
					   (@idBill
					   ,@idFood
					   ,@count)
				end
		end
end
GO
/****** Object:  StoredProcedure [dbo].[usp_LoadBill]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[usp_LoadBill]
@dayFrom date, @dayTo date
as
begin
	select t.name, b.DateCheckIn, b.DateCheckOut, b.discount, b.totalPrice from Bill b inner join TableFood t
	on b.idTable = t.id
	where @dayFrom <= b.DateCheckOut  and b.DateCheckOut <= @dayTo
end
GO
/****** Object:  StoredProcedure [dbo].[usp_SwitchTable]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_SwitchTable]
@idFromTable int, @idDesTable int
as
begin
	declare @idFromBill int
	declare @idDesBill int

	declare @isFromTableEmpty int
	declare @isDesTableEmpty int

	select @idFromBill = id from Bill where idTable = @idFromTable and status = 0
	select @idDesBill = id from Bill where idTable = @idDesTable and status = 0

	if(@idFromBill is null)
		begin

			INSERT INTO [dbo].[Bill]
				   ([DateCheckIn]
				   ,[DateCheckOut]
				   ,[idTable]
				   ,[status]
				   ,[discount])
			 VALUES
				   (GETDATE()
				   ,null
				   ,@idFromTable
				   ,0
				   ,0)
			select @idFromBill = MAX(id) from Bill where idTable = @idFromTable and status = 0
		end

	select @isFromTableEmpty = count(*) from BillInfo where idBill = @idFromBill

	if(@idDesBill is null)
		begin

			INSERT INTO [dbo].[Bill]
				   ([DateCheckIn]
				   ,[DateCheckOut]
				   ,[idTable]
				   ,[status]
				   ,[discount])
			 VALUES
				   (GETDATE()
				   ,null
				   ,@idDesTable
				   ,0
				   ,0)
			select @idDesBill = MAX(id) from Bill where idTable = @idDesTable and status = 0
		end

	select @isDesTableEmpty = count(*) from BillInfo where idBill = @idDesBill

	select id into IDBillInfoDesTable from BillInfo where idBill = @idDesBill
	update BillInfo set idBill = @idDesBill where idBill = @idFromBill
	update BillInfo set idBill = @idFromBill where id in (select * from IDBillInfoDesTable)

	drop table IDBillInfoDesTable
	if(@isFromTableEmpty = 0)
		begin
			update TableFood set status = N'Trống' where id = @idDesTable
			delete Bill where id = @idDesBill and status = 0
		end
		
	if(@isDesTableEmpty = 0)
		update TableFood set status = N'Trống' where id = @idFromTable
		delete Bill where id = @idFromBill and status = 0
end
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateAccount]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_UpdateAccount] 
@userName nvarchar(100), @displayName nvarchar(100), @pass nvarchar(100), @newPass nvarchar(100)
as
begin
	declare @isRightPass int = 0
	select @isRightPass = count(*) from Account a where a.UserName = @userName and a.PassWord = @pass
	if(@isRightPass = 1)
		begin
			if(@newPass is null or @newPass = ' ')
				begin
					update Account set DisplayName = @displayName where UserName = @userName
				end
			else
				begin
					update Account set DisplayName = @displayName, PassWord = @newPass where UserName = @userName
				end
		end
end
GO
/****** Object:  Trigger [dbo].[utg_UpdateBill]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[utg_UpdateBill]
on [dbo].[Bill] for insert, update
as
begin
	declare @idBill int
	select @idBill = id from inserted
	declare @idTable int
	select @idTable = idTable from Bill where id = @idBill
	declare @count int = 0
	select @count = COUNT(*) from Bill where idTable = @idTable and status = 0

	if(@count = 0)
		update TableFood set status = N'Trống' where id = @idTable
end
GO
ALTER TABLE [dbo].[Bill] ENABLE TRIGGER [utg_UpdateBill]
GO
/****** Object:  Trigger [dbo].[utg_DeleteBillInfo]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[utg_DeleteBillInfo]
on [dbo].[BillInfo] for delete
as
begin
	declare @idBill int
	declare @idBillInfo int

	select @idBill = idBill, @idBillInfo = id from deleted

	declare @idTable int

	select @idTable = idTable from Bill where id = @idBill and status = 0

	declare @cntBillInfo int

	select @cntBillInfo = count(*) from BillInfo bi inner join Bill b on bi.idBill = b.id
	where idBill = @idBill and b.status = 0
	if(@cntBillInfo = 0)
		begin 
			delete Bill where id = @idBill
			update TableFood set status = N'Trống' where id = @idTable
		end
end
GO
ALTER TABLE [dbo].[BillInfo] ENABLE TRIGGER [utg_DeleteBillInfo]
GO
/****** Object:  Trigger [dbo].[utg_UpdateBillInfo]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[utg_UpdateBillInfo]
on [dbo].[BillInfo] for insert, update
as
begin
	declare @idBill int 
	select @idBill = idBill from inserted

	declare @idTable int 
	select @idTable = idTable from Bill where id = @idBill and status = 0

	declare @countBillInfo int = 0
	select @countBillInfo = count(id) from BillInfo where idBill = @idBill 
	if(@countBillInfo = 0)
		begin
			delete Bill where id = @idBill
			update TableFood set status = N'Trống' where id = @idTable
		end
	else
		begin
			update TableFood set status = N'Có khách' where id = @idTable
		end
end
GO
ALTER TABLE [dbo].[BillInfo] ENABLE TRIGGER [utg_UpdateBillInfo]
GO
/****** Object:  Trigger [dbo].[utg_InsertCategor]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[utg_InsertCategor]
on [dbo].[FoodCategory] for insert, update
as
begin
	set nocount on;
	declare @CountDuplicate int = 0;

	select @CountDuplicate = count(*) from inserted i inner join FoodCategory fc
	on i.name = fc.name
	where i.id != fc.id
	
	if(@CountDuplicate > 0)
		begin
			rollback tran
		end
end
GO
ALTER TABLE [dbo].[FoodCategory] ENABLE TRIGGER [utg_InsertCategor]
GO
/****** Object:  Trigger [dbo].[utg_DeleteTable]    Script Date: 7/19/2024 3:29:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[utg_DeleteTable]
on [dbo].[TableFood] for delete
as
begin
	declare @idTable int
	select @idTable = id from deleted

	declare @cnt int = 0
	select @cnt = count(*) from Bill where idTable = @idTable and status = 0

	if(@cnt > 0)
	begin
		rollback tran
	end
end
GO
ALTER TABLE [dbo].[TableFood] ENABLE TRIGGER [utg_DeleteTable]
GO
