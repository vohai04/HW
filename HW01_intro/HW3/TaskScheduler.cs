using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler
{
    public class TaskScheduler
    {
        // TODO: Implement task queue/storage mechanism
        // Danh sách lưu trữ các công việc, readonly để tránh thay đổi ngoài ý muốn
        private readonly List<IScheduledTask> _tasks = new List<IScheduledTask>();
        // Đối tượng khóa để đảm bảo an toàn luồng khi truy cập _tasks
        private readonly object _lock = new object();

        public TaskScheduler()
        {
            // TODO: Initialize your scheduler
        }

        public void AddTask(IScheduledTask task)
        {
            // TODO: Add task to the scheduler
            lock (_lock) // Khóa để đảm bảo an toàn luồng
            {
                // Kiểm tra xem tên công việc đã tồn tại chưa
                if (_tasks.Any(t => t.Name == task.Name))
                {
                    // Ném ngoại lệ nếu tên công việc đã tồn tại
                    throw new InvalidOperationException($"Task with name '{task.Name}' already exists.");
                }
                // Thêm công việc vào danh sách
                _tasks.Add(task);
            }
        }

        public void RemoveTask(string taskName)
        {
            // TODO: Remove task from the scheduler
            lock (_lock) // Khóa để đảm bảo an toàn luồng
            {
                // Tìm công việc theo tên
                var task = _tasks.FirstOrDefault(t => t.Name == taskName);
                if (task != null)
                {
                    // Xóa công việc nếu tìm thấy
                    _tasks.Remove(task);
                }
                else
                {
                    // Ném ngoại lệ nếu không tìm thấy công việc
                    throw new InvalidOperationException($"Task with name '{taskName}' not found.");
                }
            }
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // TODO: Implement the scheduling logic
            // - Run higher priority tasks first
            // - Only run tasks when their interval has elapsed since LastRun
            // - Keep running until cancellation is requested
            while (!cancellationToken.IsCancellationRequested)
            {
                List<IScheduledTask> tasksToRun;
                lock (_lock) // Khóa để lấy bản sao danh sách công việc
                {
                    // Lấy danh sách công việc, sắp xếp theo ưu tiên giảm dần
                    tasksToRun = _tasks.OrderByDescending(t => t.Priority).ToList();
                }

                // Duyệt qua từng công việc để kiểm tra và chạy nếu đủ điều kiện
                foreach (var task in tasksToRun)
                {
                    // Kiểm tra xem đã qua đủ thời gian Interval chưa
                    if (DateTime.Now - task.LastRun >= task.Interval)
                    {
                        try
                        {
                            // Chạy công việc bất đồng bộ
                            await task.ExecuteAsync();
                        }
                        catch (Exception ex)
                        {
                            // In lỗi nếu công việc thất bại, không làm dừng scheduler
                            Console.WriteLine($"Lỗi khi thực thi công việc '{task.Name}': {ex.Message}");
                        }
                    }
                }

                // Đợi 100ms để tránh tiêu tốn CPU, vẫn phản hồi nhanh với hủy
                await Task.Delay(100, cancellationToken);
            }

            // Ném ngoại lệ nếu bị hủy
            cancellationToken.ThrowIfCancellationRequested();
        }

        public List<IScheduledTask> GetScheduledTasks()
        {
            // TODO: Return a list of all scheduled tasks
            {
                lock (_lock) // Khóa để đảm bảo an toàn luồng
                {
                    // Trả về bản sao để tránh chỉnh sửa ngoài ý muốn
                    return _tasks.ToList();
                }
            }
        }
    }
}
