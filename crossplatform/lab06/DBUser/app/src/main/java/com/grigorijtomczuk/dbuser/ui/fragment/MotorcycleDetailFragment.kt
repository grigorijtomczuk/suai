package com.grigorijtomczuk.dbuser.ui.fragment

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import androidx.navigation.fragment.navArgs
import com.grigorijtomczuk.dbuser.databinding.FragmentMotorcycleDetailBinding
import com.grigorijtomczuk.dbuser.ui.viewmodel.MotorcycleViewModel

class MotorcycleDetailFragment : Fragment() {

    private var _binding: FragmentMotorcycleDetailBinding? = null
    private val binding get() = _binding!!

    private lateinit var motorcycleViewModel: MotorcycleViewModel
    private val args by navArgs<MotorcycleDetailFragmentArgs>()

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentMotorcycleDetailBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        motorcycleViewModel = ViewModelProvider(this).get(MotorcycleViewModel::class.java)

        motorcycleViewModel.getMotorcycle(args.motorcycleId).observe(viewLifecycleOwner) { motorcycle ->
            motorcycle?.let {
                binding.tvBrandDetail.text = it.brand
                binding.tvModelDetail.text = it.model
                binding.tvYearDetail.text = it.year.toString()
            }
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}