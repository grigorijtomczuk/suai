package com.grigorijtomczuk.dbuser

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.grigorijtomczuk.dbuser.data.Motorcyclist

class MotorcyclistAdapter(
    private val onItemLongClick: (Motorcyclist) -> Unit
) : RecyclerView.Adapter<MotorcyclistAdapter.MotorcyclistViewHolder>() {

    private var motorcyclists = emptyList<Motorcyclist>()

    class MotorcyclistViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val tvBrandModel: TextView = itemView.findViewById(R.id.tvBrandModel)
        val tvOwnerYear: TextView = itemView.findViewById(R.id.tvOwnerYear)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): MotorcyclistViewHolder {
        val itemView = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_motorcyclist, parent, false)
        return MotorcyclistViewHolder(itemView)
    }

    override fun onBindViewHolder(holder: MotorcyclistViewHolder, position: Int) {
        val current = motorcyclists[position]
        holder.tvBrandModel.text = "${current.brand} ${current.model}"
        holder.tvOwnerYear.text = "Владелец: ${current.ownerName}, год: ${current.year}"

        holder.itemView.setOnLongClickListener {
            onItemLongClick(current)
            true
        }
    }

    override fun getItemCount() = motorcyclists.size

    fun setMotorcyclists(motorcyclists: List<Motorcyclist>) {
        this.motorcyclists = motorcyclists
        notifyDataSetChanged()
    }
}
