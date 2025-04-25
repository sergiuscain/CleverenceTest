
public static class Server
{
    private static int count;
    private static ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

    // Метод для чтения значения count
    public static int GetCount()
    {
        // Получаем блокировку для чтения
        rwLock.EnterReadLock();
        try
        {
            return count;
        }
        finally
        {
            // Освобождаем блокировку
            rwLock.ExitReadLock();
        }
    }

    // Метод для добавления значения к count
    public static void AddToCount(int value)
    {
        // Получаем блокировку для записи
        rwLock.EnterWriteLock();
        try
        {
            count += value;
        }
        finally
        {
            // Освобождаем блокировку
            rwLock.ExitWriteLock(); 
        }
    }
}