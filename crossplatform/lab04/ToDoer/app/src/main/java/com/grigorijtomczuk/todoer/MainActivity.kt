package com.grigorijtomczuk.todoer

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView

class MainActivity : AppCompatActivity() {

    private lateinit var tasksRecyclerView: RecyclerView
    private lateinit var newTaskEditText: EditText
    private lateinit var addTaskButton: Button
    private lateinit var tasksAdapter: TasksAdapter

    // Список задач
    private var tasks = mutableListOf(
        Task(name = "Проверить давление в шинах"),
        Task(name = "Смазать цепь"),
        Task(name = "Проверить уровень масла"),
        Task(name = "Заправиться")
    )

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        tasksRecyclerView = findViewById(R.id.tasksRecyclerView)
        newTaskEditText = findViewById(R.id.newTaskEditText)
        addTaskButton = findViewById(R.id.addTaskButton)

        tasksAdapter = TasksAdapter(
            onTaskCompleted = { clickedTask ->
                tasks = tasks.map { task ->
                    if (task.id == clickedTask.id) {
                        task.copy(isCompleted = !task.isCompleted)
                    } else {
                        task
                    }
                }.toMutableList()
                // Передаем в адаптер новую, неизменяемую копию списка
                tasksAdapter.submitList(tasks.toList())
            },
            onDeleteTask = { taskToDelete ->
                tasks = tasks.filter { it.id != taskToDelete.id }.toMutableList()
                // Передаем в адаптер новую, неизменяемую копию списка
                tasksAdapter.submitList(tasks.toList())
            }
        )

        tasksRecyclerView.adapter = tasksAdapter
        tasksRecyclerView.layoutManager = LinearLayoutManager(this)

        tasksAdapter.submitList(tasks.toList())

        addTaskButton.setOnClickListener {
            val taskName = newTaskEditText.text.toString()
            if (taskName.isNotBlank()) {
                // Создаем новый список, добавляя в него новую задачу
                tasks.add(Task(name = taskName))
                // Передаем в адаптер новую, неизменяемую копию списка
                tasksAdapter.submitList(tasks.toList())
                newTaskEditText.text.clear()
            }
        }
    }
}
