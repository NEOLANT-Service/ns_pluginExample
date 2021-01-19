export interface IP3DBPluginException extends Error {
    /**Код ошибок */
    number: P3DBPluginErrorCode;
}

export enum P3DBPluginErrorCode {
    /**Некорректный входной аргумент */
    ArgumentException = -1,
    //Если обязательные аргументы пустые, или null
    ArgumentNullException = -2,
    /**Информация не найдена/файл не найден */
    NotFoundException = 3,
    /** Если не удается прочитать файл по указанному пути из-за отсутствия полномочий на чтение*/
    UnauthorizedAccessException = -4,
    /**Невозможно выполнить операцию из за плохо состояния или текущее состояние не позволяет выполнить данную операцию*/
    InvalidOperationException = -5,
    /** Если идет попытка загрузки файла, а в сцене уже присутствует файл с этим путем / в сцену загружается файл с таким путём.*/
    AlreadyExistException = -6,
    /**Сетевая ошибка, при получении файла модели по URL */
    NetworkException = -7,
    /**Нехватка памяти */
    OutOfMemoryException = -8,
    /**Ошибка таймаута */
    TimeoutException = -9,

    /**Не реализовано */
    NotImplementedException = -10,
    
    /**Операция отменена */
    OperationCanceledException = -11,

    P3DB_LicenseException = -120,
    P3DB_LicenceExpired = -121,
    P3DB_OutOfMemoryException = -108,
    P3DB_NotImplementedException = -110,
    P3DB_InvalidOperationException = -105,
    P3DB_OperationCanceledException = -111,
    UnhandledException = -1000
}