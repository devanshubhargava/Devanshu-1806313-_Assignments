-- Table for Trains

USE Train_Reservation_Dataset;

CREATE TABLE Trains (
    TrainId INT PRIMARY KEY IDENTITY,
    TrainNo VARCHAR(10) NOT NULL,
    TrainName VARCHAR(100) NOT NULL,
    Source VARCHAR(100) NOT NULL,
    Destination VARCHAR(100) NOT NULL,
    IsActive BIT DEFAULT 1, -- Active status
    TotalSeats INT NOT NULL, -- Total number of seats in the train
    Available_FirstClassSeats INT NOT NULL,
    Available_SecondClassSeats INT NOT NULL,
    Available_SleeperClassSeats INT NOT NULL
);

-- Table for storing user information

CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY,
    UserName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL 
);

CREATE TABLE Admins (
    AdminId INT PRIMARY KEY IDENTITY,
    AdminName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL 
);

-- Table for storing tickets

CREATE TABLE Tickets (
    TicketId INT PRIMARY KEY IDENTITY,
    TrainId INT,
    UserId INT,
    Class VARCHAR(50), -- 1st, 2nd, Sleeper
    SeatCount INT,
    BookingDate DATETIME DEFAULT GETDATE(),
    IsCancelled BIT DEFAULT 0, -- To track cancellations
    FOREIGN KEY (TrainId) REFERENCES Trains(TrainId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

-- Trigger to prevent booking on non-active trains

GO
CREATE TRIGGER PreventInactiveTrainBooking
ON Tickets
AFTER INSERT
AS
BEGIN
    DECLARE @TrainId INT;
    SELECT @TrainId = TrainId FROM inserted;

    IF EXISTS (SELECT 1 FROM Trains WHERE TrainId = @TrainId AND IsActive = 0)
    BEGIN
        RAISERROR('Cannot book a ticket for an inactive train.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- Train Adding Procedure

CREATE PROCEDURE AddTrain
    @TrainNo VARCHAR(10),
    @TrainName VARCHAR(100),
    @Source VARCHAR(100),
    @Destination VARCHAR(100),
    @TotalSeats INT,
    @AvailableFirstClassSeats INT,
    @AvailableSecondClassSeats INT,
    @AvailableSleeperClassSeats INT
AS
BEGIN
    INSERT INTO Trains (TrainNo, TrainName, Source, Destination, TotalSeats, Available_FirstClassSeats, Available_SecondClassSeats, Available_SleeperClassSeats)
    VALUES (@TrainNo, @TrainName, @Source, @Destination, @TotalSeats, @AvailableFirstClassSeats, @AvailableSecondClassSeats, @AvailableSleeperClassSeats);
END;

-- Modifying Train Procedure

GO
CREATE PROCEDURE ModifyTrain
    @TrainId INT,
    @TrainNo VARCHAR(10),
    @TrainName VARCHAR(100),
    @Source VARCHAR(100),
    @Destination VARCHAR(100),
    @TotalSeats INT,
    @AvailableFirstClassSeats INT,
    @AvailableSecondClassSeats INT,
    @AvailableSleeperClassSeats INT
AS
BEGIN
    UPDATE Trains
    SET 
        TrainNo = @TrainNo,
        TrainName = @TrainName,
        Source = @Source,
        Destination = @Destination,
        TotalSeats = @TotalSeats,
        Available_FirstClassSeats = @AvailableFirstClassSeats,
        Available_SecondClassSeats = @AvailableSecondClassSeats,
        Available_SleeperClassSeats = @AvailableSleeperClassSeats
    WHERE TrainId = @TrainId;
END;
GO

-- Soft Delete Train Procedure

CREATE PROCEDURE SoftDeleteTrain
    @TrainId INT
AS
BEGIN
    UPDATE Trains
    SET IsActive = 0
    WHERE TrainId = @TrainId;
END;

-- Book Ticket Procedure

GO

CREATE PROCEDURE BookTicket
    @UserId INT,
    @TrainId INT,
    @Class VARCHAR(50),
    @SeatCount INT
AS
BEGIN
    DECLARE @AvailableSeats INT;

    -- Fetch available seats based on class

    IF @Class = '1st'
    BEGIN
        SELECT @AvailableSeats = Available_FirstClassSeats FROM Trains WHERE TrainId = @TrainId;
    END
    ELSE IF @Class = '2nd'
    BEGIN
        SELECT @AvailableSeats = Available_SecondClassSeats FROM Trains WHERE TrainId = @TrainId;
    END
    ELSE IF @Class = 'Sleeper'
    BEGIN
        SELECT @AvailableSeats = Available_SleeperClassSeats FROM Trains WHERE TrainId = @TrainId;
    END

    -- Check if sufficient seats are available

    IF @AvailableSeats >= @SeatCount
    BEGIN
        -- Book the ticket and update available seats

        INSERT INTO Tickets (TrainId, UserId, Class, SeatCount)
        VALUES (@TrainId, @UserId, @Class, @SeatCount);

        -- Update available seats

        IF @Class = '1st'
        BEGIN
            UPDATE Trains
            SET Available_FirstClassSeats = Available_FirstClassSeats - @SeatCount
            WHERE TrainId = @TrainId;
        END
        ELSE IF @Class = '2nd'
        BEGIN
            UPDATE Trains
            SET Available_SecondClassSeats = Available_SecondClassSeats - @SeatCount
            WHERE TrainId = @TrainId;
        END
        ELSE IF @Class = 'Sleeper'
        BEGIN
            UPDATE Trains
            SET Available_SleeperClassSeats = Available_SleeperClassSeats - @SeatCount
            WHERE TrainId = @TrainId;
        END
    END
    ELSE
    BEGIN
        PRINT 'Not enough seats available.';
    END
END;

GO

-- Cancel Ticket Procedure

CREATE PROCEDURE CancelTicket
    @TicketId INT
AS
BEGIN
    DECLARE @TrainId INT, @Class VARCHAR(50), @SeatCount INT;

    -- Fetch ticket details

    SELECT @TrainId = TrainId, @Class = Class, @SeatCount = SeatCount FROM Tickets WHERE TicketId = @TicketId;

    -- Update available seats based on class

    IF @Class = '1st'
    BEGIN
        UPDATE Trains
        SET Available_FirstClassSeats = Available_FirstClassSeats + @SeatCount
        WHERE TrainId = @TrainId;
    END
    ELSE IF @Class = '2nd'
    BEGIN
        UPDATE Trains
        SET Available_SecondClassSeats = Available_SecondClassSeats + @SeatCount
        WHERE TrainId = @TrainId;
    END
    ELSE IF @Class = 'Sleeper'
    BEGIN
        UPDATE Trains
        SET Available_SleeperClassSeats = Available_SleeperClassSeats + @SeatCount
        WHERE TrainId = @TrainId;
    END

    -- Mark ticket as cancelled
	
    UPDATE Tickets
    SET IsCancelled = 1
    WHERE TicketId = @TicketId;
END;
