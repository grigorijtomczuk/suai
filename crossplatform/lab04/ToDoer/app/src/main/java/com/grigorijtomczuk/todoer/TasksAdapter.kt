package com.grigorijtomczuk.todoer

import android.graphics.Paint
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.CheckBox
import android.widget.TextView
import androidx.recyclerview.widget.DiffUtil
import androidx.recyclerview.widget.ListAdapter
import androidx.recyclerview.widget.RecyclerView

class TasksAdapter(
    private val onTaskCompleted: (Task) -> Unit,
    private val onDeleteTask: (Task) -> Unit
) : ListAdapter<Task, TasksAdapter.TaskViewHolder>(TaskDiffCallback()) {

    // ViewHolder хранит ссылки на View элементы для каждого элемента списка
    class TaskViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val taskNameTextView: TextView = itemView.findViewById(R.id.taskNameTextView)
        val taskCheckBox: CheckBox = itemView.findViewById(R.id.taskCheckBox)
        val deleteTaskButton: Button = itemView.findViewById(R.id.deleteTaskButton)

        fun bind(task: Task, onTaskCompleted: (Task) -> Unit, onDeleteTask: (Task) -> Unit) {
            taskNameTextView.text = task.name
            taskCheckBox.isChecked = task.isCompleted
            toggleStrikeThrough(taskNameTextView, task.isCompleted)

            taskCheckBox.setOnClickListener {
                onTaskCompleted(task)
            }
            deleteTaskButton.setOnClickListener {
                onDeleteTask(task)
            }
        }

        private fun toggleStrikeThrough(textView: TextView, isChecked: Boolean) {
            if (isChecked) {
                textView.paintFlags = textView.paintFlags or Paint.STRIKE_THRU_TEXT_FLAG
            } else {
                textView.paintFlags = textView.paintFlags and Paint.STRIKE_THRU_TEXT_FLAG.inv()
            }
        }
    }

    // Вызывается, когда RecyclerView требует новый ViewHolder для отображения элемента
    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): TaskViewHolder {
        val itemView = LayoutInflater.from(parent.context)
            .inflate(R.layout.task_item, parent, false)
        return TaskViewHolder(itemView)
    }

    override fun onBindViewHolder(holder: TaskViewHolder, position: Int) {
        val task = getItem(position)
        holder.bind(task, onTaskCompleted, onDeleteTask)
    }
}

class TaskDiffCallback : DiffUtil.ItemCallback<Task>() {
    override fun areItemsTheSame(oldItem: Task, newItem: Task): Boolean {
        return oldItem.id == newItem.id
    }

    override fun areContentsTheSame(oldItem: Task, newItem: Task): Boolean {
        return oldItem == newItem
    }
}
